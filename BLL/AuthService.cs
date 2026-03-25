using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using LibraryManagement.DAL;
using LibraryManagement.Helpers;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class AuthService
    {
        private readonly UserDAL _userDAL;

        public AuthService()
        {
            _userDAL = new UserDAL();
        }

        public AuthValidationResult<Employee> Login(string email, string password)
        {
            email = (email ?? "").Trim();
            password = password ?? "";

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(password))
            {
                return AuthValidationResult<Employee>.Fail("Email and password are required.");
            }

            // Fetch user by email
            Employee emp = _userDAL.GetByEmail(email);

            if (emp == null)
            {
                return AuthValidationResult<Employee>.Fail("Invalid email or password.");
            }

            // Status check
            if (!emp.IsActive)
            {
                return AuthValidationResult<Employee>.Fail("This account has been deactivated.");
            }

            // Verify password with BCrypt
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(password, emp.HashedPassword);
            if (!passwordMatches)
            {
                return AuthValidationResult<Employee>.Fail("Invalid email or password.");
            }

            // Try to acquire login lock using a new dedicated lock connection.
            SqlConnection lockConnection = null;
            try
            {
                lockConnection = clsDatabase.CreateOpenConnection();
                bool lockAcquired = _userDAL.AcquireLoginLock(lockConnection, emp.Email);

                if (!lockAcquired)
                {
                    lockConnection.Dispose();
                    return AuthValidationResult<Employee>.Fail("Account is already logged in on another device.");
                }

                // Lock succeeded — set session and keep lockConnection OPEN
                SessionManager.SetSession(emp, lockConnection);
                lockConnection = null; // ownership transferred to SessionManager
            }
            finally
            {
                lockConnection?.Dispose();
            }

            return AuthValidationResult<Employee>.Ok(emp);
        }

        public AuthValidationResult<bool> Register(string name, string email, string password)
        {
            name = (name ?? "").Trim();
            email = (email ?? "").Trim();
            password = password ?? "";

            // Basic format validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return AuthValidationResult<bool>.Fail("Name, email, and password are required.");
            }

            if (!IsValidEmail(email))
            {
                return AuthValidationResult<bool>.Fail("Invalid email format.");
            }

            if (email.Length > 30)
            {
                return AuthValidationResult<bool>.Fail("Email cannot be longer than 30 characters.");
            }

            if (password.Length < 8)
            {
                return AuthValidationResult<bool>.Fail("Password must be at least 8 characters long.");
            }

            // Normalize email and check uniqueness
            string normalizedEmail = email.ToLowerInvariant();
            if (_userDAL.EmailExists(normalizedEmail))
            {
                return AuthValidationResult<bool>.Fail("Email is already in use.");
            }

            // Hash password (cost 10)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 10);

            // Create and save employee
            var newEmp = new Employee
            {
                Name = name,
                Email = normalizedEmail
            };

            bool sqlSuccess = _userDAL.Register(newEmp, hashedPassword);
            if (!sqlSuccess)
            {
                return AuthValidationResult<bool>.Fail("Registration failed due to a database error.");
            }

            return AuthValidationResult<bool>.Ok(true);
        }

        public AuthValidationResult<bool> UpdateProfile(
            int employeeId, string name, string phone, string address,
            string sourceImagePath, string originalImagePath, string imagesDir)
        {
            name    = (name    ?? "").Trim();
            phone   = (phone   ?? "").Trim();
            address = (address ?? "").Trim();

            // Validate name
            if (string.IsNullOrWhiteSpace(name))
                return AuthValidationResult<bool>.Fail("Full Name is required.");

            // Validate phone format
            if (phone.Length > 0 && !Regex.IsMatch(phone, @"^[\d\+\-\s]+$"))
                return AuthValidationResult<bool>.Fail("Phone can only contain digits, spaces, +, and -");

            // Validate address length
            if (address.Length > 500)
                return AuthValidationResult<bool>.Fail("Address is too long (max 500 chars).");

            // Copy image to app storage if a new one was selected
            string finalImagePath = sourceImagePath;
            if (sourceImagePath != originalImagePath && !string.IsNullOrEmpty(sourceImagePath))
            {
                try
                {
                    if (!Directory.Exists(imagesDir))
                        Directory.CreateDirectory(imagesDir);

                    string ext      = Path.GetExtension(sourceImagePath);
                    string fileName = $"emp_{employeeId}_{DateTime.Now.Ticks}{ext}";
                    finalImagePath  = Path.Combine(imagesDir, fileName);
                    File.Copy(sourceImagePath, finalImagePath, overwrite: true);
                }
                catch (Exception ex)
                {
                    return AuthValidationResult<bool>.Fail("Failed to save image: " + ex.Message);
                }
            }

            // Persist to DB
            bool sqlSuccess = _userDAL.UpdateProfile(employeeId, name, phone, address, finalImagePath ?? "");
            if (!sqlSuccess)
                return AuthValidationResult<bool>.Fail("Failed to update profile due to a database error or invalid employee ID.");

            // Update the live session state
            if (SessionManager.IsLoggedIn && SessionManager.CurrentEmployee.Id == employeeId)
            {
                SessionManager.CurrentEmployee.Name      = name;
                SessionManager.CurrentEmployee.Phone     = string.IsNullOrEmpty(phone)          ? null : phone;
                SessionManager.CurrentEmployee.Address   = string.IsNullOrEmpty(address)        ? null : address;
                SessionManager.CurrentEmployee.ImagePath = string.IsNullOrEmpty(finalImagePath) ? null : finalImagePath;
            }

            return AuthValidationResult<bool>.Ok(true);
        }

        public AuthValidationResult<bool> ChangePassword(Models.Employee employee, string currentPassword, string newPassword)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            // Re-fetch the current hash from DB
            Models.Employee fresh = _userDAL.GetByEmail(employee.Email);
            if (fresh == null)
                return AuthValidationResult<bool>.Fail("Account not found.");

            // Verify supplied current password
            bool matches = BCrypt.Net.BCrypt.Verify(currentPassword, fresh.HashedPassword);
            if (!matches)
                return AuthValidationResult<bool>.Fail("Current password is incorrect.");

            // Hash the new password
            string newHash = BCrypt.Net.BCrypt.HashPassword(newPassword, 10);

            // Persist the new hash
            bool ok = _userDAL.UpdatePassword(employee.Id, newHash);
            if (!ok)
                return AuthValidationResult<bool>.Fail("Failed to update password in the database.");

            return AuthValidationResult<bool>.Ok(true);
        }
        // ── Validation Helpers ────
        public static bool IsValidEmail(string email)
            => Regex.IsMatch(email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public static PasswordStrength CalculatePasswordStrength(string password)
        {
            if (password == null || password.Length == 0) return PasswordStrength.None;
            if (password.Length < 8) return PasswordStrength.Weak;

            bool hasUpper   = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower   = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit   = Regex.IsMatch(password, @"\d");
            bool hasSpecial = Regex.IsMatch(password, @"[^A-Za-z0-9]");
            bool isStrong   = password.Length >= 12
                           || (hasUpper && hasLower && hasDigit && hasSpecial);

            return isStrong ? PasswordStrength.Strong : PasswordStrength.Medium;
        }
    }

    public enum PasswordStrength { None, Weak, Medium, Strong }

    public class AuthValidationResult<T>
    {
        public bool Success { get; }
        public string ErrorMessage { get; }
        public T Data { get; }

        private AuthValidationResult(bool success, string errorMessage, T data)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public static AuthValidationResult<T> Ok(T data)
        {
            return new AuthValidationResult<T>(true, string.Empty, data);
        }

        public static AuthValidationResult<T> Fail(string errorMessage)
        {
            return new AuthValidationResult<T>(false, errorMessage, default(T));
        }
    }

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("The supplied password is incorrect.") { }

        public InvalidPasswordException(string message)
            : base(message) { }

        public InvalidPasswordException(string message, Exception inner)
            : base(message, inner) { }
    }
}
