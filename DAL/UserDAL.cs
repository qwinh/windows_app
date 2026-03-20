using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using LibraryManagement.Helpers;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class UserDAL
    {
        public Employee GetByEmail(string email)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(
                "SELECT id, name, email, pass, phone, address, image_path, date_create, status " +
                "FROM employees WHERE email = @email", conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapFromReader(reader);
                    }
                }
            }
            return null;
        }

        public bool EmailExists(string email)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(1) FROM employees WHERE email = @email", conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool Register(Employee emp, string hashedPassword)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(
                "INSERT INTO employees (name, email, pass, phone, address, status, date_create) " +
                "VALUES (@name, @email, @pass, @phone, @address, @status, SYSDATETIME())", conn))
            {
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@pass", hashedPassword);
                
                // Handle optional fields
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(emp.Phone) ? (object)DBNull.Value : emp.Phone);
                cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(emp.Address) ? (object)DBNull.Value : emp.Address);
                
                // Status defaults to 1 (active) per schema, but we'll set it explicitly
                cmd.Parameters.AddWithValue("@status", 1);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Acquires an exclusive application lock to prevent multiple logins.
        /// Uses the connection provided, does NOT close it.
        /// </summary>
        public bool AcquireLoginLock(SqlConnection lockConn, string email)
        {
            string resource = BuildLoginLockResource(email);
            using (var cmd = new SqlCommand("sp_getapplock", lockConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@Resource", SqlDbType.NVarChar, 255).Value = resource;
                cmd.Parameters.AddWithValue("@LockMode", "Exclusive");
                cmd.Parameters.AddWithValue("@LockOwner", "Session");
                cmd.Parameters.AddWithValue("@LockTimeout", 0); // Fail immediately if locked

                var returnParam = new SqlParameter
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(returnParam);

                cmd.ExecuteNonQuery();

                int result = (int)returnParam.Value;
                // @result >= 0 -> lock acquired successfully
                return result >= 0;
            }
        }

        private static string BuildLoginLockResource(string email)
        {
            string normalized = (email ?? "").Trim().ToLowerInvariant();
            const string prefix = "login_user_";

            if (prefix.Length + normalized.Length <= 255)
            {
                return prefix + normalized;
            }

            using (var sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(normalized);
                byte[] hashBytes = sha.ComputeHash(bytes);
                var hashHex = BitConverter.ToString(hashBytes).Replace("-", "");
                return prefix + hashHex;
            }
        }

        public bool UpdateProfile(int id, string name, string phone, string address, string imagePath)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(
                "UPDATE employees SET name = @name, phone = @phone, address = @address, image_path = @imagePath " +
                "WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                
                // Handle optional fields
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                cmd.Parameters.AddWithValue("@imagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        private Employee MapFromReader(SqlDataReader reader)
        {
            return new Employee
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = reader["name"].ToString(),
                Email = reader["email"].ToString(),
                HashedPassword = reader["pass"].ToString(),
                Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : null,
                Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : null,
                ImagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : null,
                DateCreate = Convert.ToDateTime(reader["date_create"]),
                Status = Convert.ToByte(reader["status"])
            };
        }
    }
}
