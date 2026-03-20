using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryManagement.Helpers;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class BookActualDAL
    {
        public List<BookActual> GetAvailableBooks()
        {
            var books = new List<BookActual>();
            
            // Get physical books that are NOT currently borrowed (date_return is NULL in borrows for that book)
            string query = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name,
                       bf.image_path,
                       (SELECT TOP 1 a.name FROM authors a INNER JOIN books_formal_authors bfa ON a.id = bfa.authors_id WHERE bfa.books_formal_id = bf.id) AS author_name
                FROM books_actual ba
                INNER JOIN books_formal bf ON ba.books_formal_id = bf.id
                WHERE ba.id NOT IN (
                    SELECT books_actual_id FROM borrows WHERE date_return IS NULL
                )
                ORDER BY bf.name, ba.id";
                           
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new BookActual
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            FormalId = Convert.ToInt32(reader["books_formal_id"]),
                            DateCreate = Convert.ToDateTime(reader["date_create"]),
                            Integrity = Convert.ToByte(reader["integrity"]),
                            FormalName = reader["formal_name"].ToString(),
                            ImagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : null,
                            AuthorName = reader["author_name"] != DBNull.Value ? reader["author_name"].ToString() : null
                        });
                    }
                }
            }
            
            return books;
        }

        public List<BookActual> GetBorrowedBooks()
        {
            var books = new List<BookActual>();
            
            // Get physical books that ARE currently borrowed
            string query = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name,
                       bf.image_path,
                       (SELECT TOP 1 a.name FROM authors a INNER JOIN books_formal_authors bfa ON a.id = bfa.authors_id WHERE bfa.books_formal_id = bf.id) AS author_name
                FROM books_actual ba
                INNER JOIN books_formal bf ON ba.books_formal_id = bf.id
                WHERE ba.id IN (
                    SELECT books_actual_id FROM borrows WHERE date_return IS NULL
                )
                ORDER BY bf.name, ba.id";
                           
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new BookActual
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            FormalId = Convert.ToInt32(reader["books_formal_id"]),
                            DateCreate = Convert.ToDateTime(reader["date_create"]),
                            Integrity = Convert.ToByte(reader["integrity"]),
                            FormalName = reader["formal_name"].ToString(),
                            ImagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : null,
                            AuthorName = reader["author_name"] != DBNull.Value ? reader["author_name"].ToString() : null
                        });
                    }
                }
            }
            
            return books;
        }

        public List<BookActual> GetBorrowedBooksByReader(int readerId)
        {
            var books = new List<BookActual>();
            
            // Get physical books that ARE currently borrowed by a specific reader
            string query = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name,
                       bf.image_path,
                       (SELECT TOP 1 a.name FROM authors a INNER JOIN books_formal_authors bfa ON a.id = bfa.authors_id WHERE bfa.books_formal_id = bf.id) AS author_name
                FROM books_actual ba
                INNER JOIN books_formal bf ON ba.books_formal_id = bf.id
                WHERE ba.id IN (
                    SELECT books_actual_id FROM borrows WHERE date_return IS NULL AND readers_id = @readerId
                )
                ORDER BY bf.name, ba.id";
                           
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@readerId", readerId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new BookActual
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            FormalId = Convert.ToInt32(reader["books_formal_id"]),
                            DateCreate = Convert.ToDateTime(reader["date_create"]),
                            Integrity = Convert.ToByte(reader["integrity"]),
                            FormalName = reader["formal_name"].ToString(),
                            ImagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : null,
                            AuthorName = reader["author_name"] != DBNull.Value ? reader["author_name"].ToString() : null
                        });
                    }
                }
            }
            
            return books;
        }

        public bool ReturnBook(int bookId)
        {
            // Find the active borrow record for this physical book and set its return date
            string query = @"
                UPDATE borrows 
                SET date_return = GETDATE()
                WHERE books_actual_id = @bookId 
                  AND date_return IS NULL";
                  
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@bookId", bookId);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool IssueBook(int readerId, int bookId, int employeeId, DateTime expireDate)
        {
            // Insert a new borrow record
            string query = @"
                INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
                VALUES (@readerId, @bookId, @employeeId, GETDATE(), @expireDate, NULL)";
                  
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@readerId", readerId);
                cmd.Parameters.AddWithValue("@bookId", bookId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId); // Comes from logged in user ideally
                cmd.Parameters.AddWithValue("@expireDate", expireDate);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    public class BookFormalDAL
    {
        public List<Author> GetAuthors()
        {
            var list = new List<Author>();
            string query = "SELECT id, name FROM authors ORDER BY name";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Author { Id = Convert.ToInt32(reader["id"]), Name = reader["name"].ToString() });
                }
            }
            return list;
        }

        public List<Genre> GetGenres()
        {
            var list = new List<Genre>();
            string query = "SELECT id, name FROM genres ORDER BY name";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Genre { Id = Convert.ToInt32(reader["id"]), Name = reader["name"].ToString() });
                }
            }
            return list;
        }

        public List<BookFormal> GetAllBooksFormal()
        {
            var list = new List<BookFormal>();
            string query = @"
                SELECT bf.id, bf.name, bf.date_publish, bf.image_path,
                       (SELECT TOP 1 a.name FROM authors a INNER JOIN books_formal_authors bfa ON a.id = bfa.authors_id WHERE bfa.books_formal_id = bf.id) AS author_name,
                       (SELECT TOP 1 a.id FROM authors a INNER JOIN books_formal_authors bfa ON a.id = bfa.authors_id WHERE bfa.books_formal_id = bf.id) AS author_id,
                       (SELECT TOP 1 g.name FROM genres g INNER JOIN books_formal_genres bfg ON g.id = bfg.genres_id WHERE bfg.books_formal_id = bf.id) AS genre_name,
                       (SELECT TOP 1 g.id FROM genres g INNER JOIN books_formal_genres bfg ON g.id = bfg.genres_id WHERE bfg.books_formal_id = bf.id) AS genre_id,
                       (SELECT COUNT(*) FROM books_actual ba WHERE ba.books_formal_id = bf.id) AS total_copies
                FROM books_formal bf
                ORDER BY bf.name";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new BookFormal
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        DatePublish = reader["date_publish"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["date_publish"]) : null,
                        ImagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : null,
                        AuthorName = reader["author_name"] != DBNull.Value ? reader["author_name"].ToString() : null,
                        AuthorId = reader["author_id"] != DBNull.Value ? Convert.ToInt32(reader["author_id"]) : 0,
                        GenreName = reader["genre_name"] != DBNull.Value ? reader["genre_name"].ToString() : null,
                        GenreId = reader["genre_id"] != DBNull.Value ? Convert.ToInt32(reader["genre_id"]) : 0,
                        TotalCopies = Convert.ToInt32(reader["total_copies"])
                    });
                }
            }
            return list;
        }

        public bool AddBook(BookFormal book, int copiesCount)
        {
            string query = @"
                BEGIN TRANSACTION;
                DECLARE @newBookId INT;
                INSERT INTO books_formal (name, date_publish, image_path)
                VALUES (@name, @datePublish, @imagePath);
                SET @newBookId = SCOPE_IDENTITY();
                
                IF @authorId > 0
                    INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (@newBookId, @authorId);
                IF @genreId > 0
                    INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (@newBookId, @genreId);
                
                DECLARE @i INT = 0;
                WHILE @i < @copiesCount
                BEGIN
                    INSERT INTO books_actual (books_formal_id, integrity) VALUES (@newBookId, 5);
                    SET @i = @i + 1;
                END
                
                COMMIT;";
            try
            {
                using (var conn = clsDatabase.CreateOpenConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", book.Name);
                    cmd.Parameters.AddWithValue("@datePublish", book.DatePublish.HasValue ? (object)book.DatePublish.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@imagePath", string.IsNullOrEmpty(book.ImagePath) ? DBNull.Value : (object)book.ImagePath);
                    cmd.Parameters.AddWithValue("@authorId", book.AuthorId);
                    cmd.Parameters.AddWithValue("@genreId", book.GenreId);
                    cmd.Parameters.AddWithValue("@copiesCount", copiesCount);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateBook(BookFormal book)
        {
            string query = @"
                BEGIN TRANSACTION;
                UPDATE books_formal SET name = @name, date_publish = @datePublish, image_path = @imagePath WHERE id = @id;
                
                DELETE FROM books_formal_authors WHERE books_formal_id = @id;
                IF @authorId > 0
                    INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (@id, @authorId);
                    
                DELETE FROM books_formal_genres WHERE books_formal_id = @id;
                IF @genreId > 0
                    INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (@id, @genreId);
                COMMIT;";
            try
            {
                using (var conn = clsDatabase.CreateOpenConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", book.Id);
                    cmd.Parameters.AddWithValue("@name", book.Name);
                    cmd.Parameters.AddWithValue("@datePublish", book.DatePublish.HasValue ? (object)book.DatePublish.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@imagePath", string.IsNullOrEmpty(book.ImagePath) ? DBNull.Value : (object)book.ImagePath);
                    cmd.Parameters.AddWithValue("@authorId", book.AuthorId);
                    cmd.Parameters.AddWithValue("@genreId", book.GenreId);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBook(int id)
        {
            string query = @"
                BEGIN TRY
                    BEGIN TRANSACTION;
                    DELETE FROM books_formal_authors WHERE books_formal_id = @id;
                    DELETE FROM books_formal_genres WHERE books_formal_id = @id;
                    DELETE FROM books_actual WHERE books_formal_id = @id;
                    DELETE FROM books_formal WHERE id = @id;
                    COMMIT;
                END TRY
                BEGIN CATCH
                    IF @@TRANCOUNT > 0
                        ROLLBACK TRANSACTION;
                    THROW;
                END CATCH;";
            try
            {
                using (var conn = clsDatabase.CreateOpenConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                // Likely due to foreign key constraints (e.g., active/past borrows)
                return false;
            }
        }
    }
}
