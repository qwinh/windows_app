using System;

namespace LibraryManagement.Models
{
    /// <summary>
    /// Maps all columns from the employees table.
    /// employees are the login accounts for the application (library staff).
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }

        /// <summary>Full display name of the employee.</summary>
        public string Name { get; set; }

        /// <summary>Email address — used as the login username. Must be unique.</summary>
        public string Email { get; set; }

        /// <summary>BCrypt hash of the password — never the plain-text value.</summary>
        public string HashedPassword { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCreate { get; set; }

        /// <summary>1 = active (can log in), 0 = deactivated (login blocked).</summary>
        public byte Status { get; set; }

        public bool IsActive => Status == 1;
    }
}
