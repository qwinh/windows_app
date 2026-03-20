using System;
using System.Data.SqlClient;
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

        /// <summary>
        /// Attempts to log in a user.
        /// Returns a structured validation result instead of throwing.
        /// </summary>
        public AuthValidationResult<Employee> Login(string email, string password)
        {
            email = (email ?? "").Trim();
            password = password ?? "";

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(password))
            {
                return AuthValidationResult<Employee>.Fail("Email and password are required.");
            }

            // 1. Fetch user by email
            Employee emp = _userDAL.GetByEmail(email);

            // 2. Base checks & generic error message (do not reveal if email exists)
            if (emp == null)
            {
                return AuthValidationResult<Employee>.Fail("Invalid email or password.");
            }

            // 3. Status check
            if (!emp.IsActive)
            {
                return AuthValidationResult<Employee>.Fail("This account has been deactivated.");
            }

            // 4. Verify password with BCrypt
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(password, emp.HashedPassword);
            if (!passwordMatches)
            {
                return AuthValidationResult<Employee>.Fail("Invalid email or password.");
            }

            // 5. Try to acquire login lock using a NEW dedicated lock connection.
            //    If anything fails after opening this connection, make sure we dispose it.
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

                // 6. Lock succeeded — set session and keep lockConnection OPEN
                SessionManager.SetSession(emp, lockConnection);
                lockConnection = null; // ownership transferred to SessionManager
            }
            finally
            {
                lockConnection?.Dispose();
            }

            return AuthValidationResult<Employee>.Ok(emp);
        }

        /// <summary>
        /// Registers a new user. Returns a structured validation result instead of throwing.
        /// </summary>
        public AuthValidationResult<bool> Register(string name, string email, string password)
        {
            name = (name ?? "").Trim();
            email = (email ?? "").Trim();
            password = password ?? "";

            // 1. Basic format validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return AuthValidationResult<bool>.Fail("Name, email, and password are required.");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                return AuthValidationResult<bool>.Fail("Invalid email format.");
            }

            if (password.Length < 8)
            {
                return AuthValidationResult<bool>.Fail("Password must be at least 8 characters long.");
            }

            // 2. Normalize email and check uniqueness
            string normalizedEmail = email.ToLowerInvariant();
            if (_userDAL.EmailExists(normalizedEmail))
            {
                return AuthValidationResult<bool>.Fail("Email is already in use.");
            }

            // 3. Hash password (cost 10)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 10);

            // 4. Create and save employee
            var newEmp = new Employee
            {
                Name = name,
                Email = normalizedEmail
                // phone and address can be updated later by admin
            };

            bool sqlSuccess = _userDAL.Register(newEmp, hashedPassword);
            if (!sqlSuccess)
            {
                return AuthValidationResult<bool>.Fail("Registration failed due to a database error.");
            }

            return AuthValidationResult<bool>.Ok(true);
        }

        /// <summary>
        /// Updates the profile (Name, Phone, Address, ImagePath) of an existing employee.
        /// Returns a structured validation result.
        /// </summary>
        public AuthValidationResult<bool> UpdateProfile(int employeeId, string name, string phone, string address, string imagePath)
        {
            name = (name ?? "").Trim();
            phone = (phone ?? "").Trim();
            address = (address ?? "").Trim();
            imagePath = (imagePath ?? "").Trim();

            // 1. Basic format validation
            if (string.IsNullOrWhiteSpace(name))
            {
                return AuthValidationResult<bool>.Fail("Full Name is required.");
            }

            // 2. Perform DB update
            bool sqlSuccess = _userDAL.UpdateProfile(employeeId, name, phone, address, imagePath);
            if (!sqlSuccess)
            {
                return AuthValidationResult<bool>.Fail("Failed to update profile due to a database error or invalid employee ID.");
            }

            // 3. Update the session state immediately to reflect changes
            if (SessionManager.IsLoggedIn && SessionManager.CurrentEmployee.Id == employeeId)
            {
                SessionManager.CurrentEmployee.Name = name;
                SessionManager.CurrentEmployee.Phone = string.IsNullOrEmpty(phone) ? null : phone;
                SessionManager.CurrentEmployee.Address = string.IsNullOrEmpty(address) ? null : address;
                SessionManager.CurrentEmployee.ImagePath = string.IsNullOrEmpty(imagePath) ? null : imagePath;
            }

            return AuthValidationResult<bool>.Ok(true);
        }
        /// <summary>
        /// FEATURE: Change password — verifies current password then updates hash.
        /// Returns a structured validation result instead of throwing.
        /// </summary>
        public AuthValidationResult<bool> ChangePassword(Models.Employee employee, string currentPassword, string newPassword)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            // 1. Re-fetch the current hash from DB
            Models.Employee fresh = _userDAL.GetByEmail(employee.Email);
            if (fresh == null)
                return AuthValidationResult<bool>.Fail("Account not found.");

            // 2. Verify supplied current password
            bool matches = BCrypt.Net.BCrypt.Verify(currentPassword, fresh.HashedPassword);
            if (!matches)
                return AuthValidationResult<bool>.Fail("Current password is incorrect.");

            // 3. Hash the new password
            string newHash = BCrypt.Net.BCrypt.HashPassword(newPassword, 10);

            // 4. Persist the new hash
            bool ok = _userDAL.UpdatePassword(employee.Id, newHash);
            if (!ok)
                return AuthValidationResult<bool>.Fail("Failed to update password in the database.");

            return AuthValidationResult<bool>.Ok(true);
        }
    }

    // ---------------------------------------------------------------------------
    // Moved from AuthValidationResult.cs — kept in the same namespace/assembly
    // ---------------------------------------------------------------------------
    /// <summary>
    /// Encapsulates the result of an authentication operation (Login/Register).
    /// Prevents the need to throw generic Exceptions for validation failures.
    /// </summary>
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

    // ---------------------------------------------------------------------------
    // Moved from InvalidPasswordException.cs — kept in the same namespace/assembly
    // ---------------------------------------------------------------------------
    /// <summary>
    /// Thrown when a supplied password does not match the stored hash.
    /// </summary>
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
