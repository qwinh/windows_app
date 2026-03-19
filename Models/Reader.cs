using System;

namespace LibraryManagement.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateExpire { get; set; }
        public byte Integrity { get; set; } = 5;  // 1 (worst) to 5 (best)
        public string ImagePath { get; set; }      // optional profile photo path

        public string DisplayName => $"{Name} ({Id})";
    }
}