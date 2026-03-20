using System;

namespace LibraryManagement.Models
{
    public class BookActual
    {
        public int Id { get; set; }
        public int FormalId { get; set; }
        public DateTime DateCreate { get; set; }
        public byte Integrity { get; set; }
        
        // Extended property from JOIN with books_formal
        public string FormalName { get; set; }
        
        // Extended property from JOIN with authors and books_formal
        public string AuthorName { get; set; }
        public string ImagePath { get; set; }
        
        // Display property for DropDowns
        public string DisplayTitle => $"{FormalName} (Copy {Id})";
    }
}
