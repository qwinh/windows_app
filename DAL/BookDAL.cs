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
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
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
                            FormalName = reader["formal_name"].ToString()
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
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
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
                            FormalName = reader["formal_name"].ToString()
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
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
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
                            FormalName = reader["formal_name"].ToString()
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
}
