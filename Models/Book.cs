using System;

namespace LibraryManagement.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BookFormal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DatePublish { get; set; }
        public string ImagePath { get; set; }
        
        // Joined fields for display
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int TotalCopies { get; set; }
    }

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
