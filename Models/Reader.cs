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
        public DateTime DateCreate { get; set; }
        public DateTime? DateExpire { get; set; }
        public byte Integrity { get; set; }
        
        // Display property for DropDowns
        public string DisplayName => $"{Name} ({Id})";
    }
}
