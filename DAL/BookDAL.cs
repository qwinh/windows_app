using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryManagement.Helpers;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    // ─── Formal Book (title/catalogue entry) ────────────────────────────────
    public class BookFormal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DatePublish { get; set; }
        public string ImagePath { get; set; }
        public List<int> AuthorIds { get; set; } = new List<int>();
        public List<int> GenreIds { get; set; } = new List<int>();

        // Count of physical copies (populated by queries that JOIN books_actual)
        public int CopyCount { get; set; }
    }

    public class BookFormalDAL
    {
        // ── READ ALL ────────────────────────────────────────────────────────
        public List<BookFormal> GetAll()
        {
            var list = new List<BookFormal>();
            const string sql = @"
                SELECT bf.id, bf.name, bf.date_publish, bf.image_path,
                       COUNT(ba.id) AS copy_count
                FROM   books_formal bf
                LEFT   JOIN books_actual ba ON ba.books_formal_id = bf.id
                GROUP  BY bf.id, bf.name, bf.date_publish, bf.image_path
                ORDER  BY bf.name";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    list.Add(Map(rdr));
            return list;
        }

        // ── SEARCH ──────────────────────────────────────────────────────────
        public List<BookFormal> Search(string keyword)
        {
            var list = new List<BookFormal>();
            const string sql = @"
                SELECT bf.id, bf.name, bf.date_publish, bf.image_path,
                       COUNT(ba.id) AS copy_count
                FROM   books_formal bf
                LEFT   JOIN books_actual ba ON ba.books_formal_id = bf.id
                WHERE  bf.name LIKE @kw
                GROUP  BY bf.id, bf.name, bf.date_publish, bf.image_path
                ORDER  BY bf.name";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                        list.Add(Map(rdr));
            }
            return list;
        }

        // ── INSERT ──────────────────────────────────────────────────────────
        /// <summary>Inserts a new formal book entry. Returns the new ID.</summary>
        public int Insert(BookFormal book)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    const string sql = @"
                        INSERT INTO books_formal (name, date_publish, image_path)
                        VALUES (@name, @date, @img);
                        SELECT SCOPE_IDENTITY();";

                    int fid;
                    using (var cmd = new SqlCommand(sql, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@name", book.Name);
                        cmd.Parameters.AddWithValue("@date", (object)book.DatePublish ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@img", (object)book.ImagePath ?? DBNull.Value);
                        fid = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (book.AuthorIds != null)
                        foreach (var a in book.AuthorIds)
                            using (var cmd = new SqlCommand("INSERT INTO books_formal_authors(books_formal_id, authors_id) VALUES(@f,@a)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@f", fid);
                                cmd.Parameters.AddWithValue("@a", a);
                                cmd.ExecuteNonQuery();
                            }

                    if (book.GenreIds != null)
                        foreach (var g in book.GenreIds)
                            using (var cmd = new SqlCommand("INSERT INTO books_formal_genres(books_formal_id, genres_id) VALUES(@f,@g)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@f", fid);
                                cmd.Parameters.AddWithValue("@g", g);
                                cmd.ExecuteNonQuery();
                            }

                    tx.Commit();
                    return fid;
                }
                catch { tx.Rollback(); throw; }
            }
        }

        // ── UPDATE ──────────────────────────────────────────────────────────
        public bool Update(BookFormal book)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    const string sql = @"
                        UPDATE books_formal
                        SET    name        = @name,
                               date_publish = @date,
                               image_path  = @img
                        WHERE  id = @id";

                    using (var cmd = new SqlCommand(sql, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@name", book.Name);
                        cmd.Parameters.AddWithValue("@date", (object)book.DatePublish ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@img", (object)book.ImagePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", book.Id);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new SqlCommand("DELETE FROM books_formal_authors WHERE books_formal_id=@id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", book.Id);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand("DELETE FROM books_formal_genres WHERE books_formal_id=@id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", book.Id);
                        cmd.ExecuteNonQuery();
                    }

                    if (book.AuthorIds != null)
                        foreach (var a in book.AuthorIds)
                            using (var cmd = new SqlCommand("INSERT INTO books_formal_authors(books_formal_id, authors_id) VALUES(@f,@a)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@f", book.Id);
                                cmd.Parameters.AddWithValue("@a", a);
                                cmd.ExecuteNonQuery();
                            }

                    if (book.GenreIds != null)
                        foreach (var g in book.GenreIds)
                            using (var cmd = new SqlCommand("INSERT INTO books_formal_genres(books_formal_id, genres_id) VALUES(@f,@g)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@f", book.Id);
                                cmd.Parameters.AddWithValue("@g", g);
                                cmd.ExecuteNonQuery();
                            }

                    tx.Commit();
                    return true;
                }
                catch { tx.Rollback(); throw; }
            }
        }

        public List<int> GetAuthorIds(int formalId)
        {
            var list = new List<int>();
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand("SELECT authors_id FROM books_formal_authors WHERE books_formal_id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", formalId);
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read()) list.Add(Convert.ToInt32(rdr[0]));
            }
            return list;
        }

        public List<int> GetGenreIds(int formalId)
        {
            var list = new List<int>();
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand("SELECT genres_id FROM books_formal_genres WHERE books_formal_id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", formalId);
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read()) list.Add(Convert.ToInt32(rdr[0]));
            }
            return list;
        }

        // ── DELETE ──────────────────────────────────────────────────────────
        /// <summary>
        /// Deletes the formal book AND all its physical copies.
        /// Returns false if any copy is currently borrowed.
        /// </summary>
        public bool Delete(int id)
        {
            // Safety: refuse if any copy is on loan
            const string checkSql = @"
                SELECT COUNT(*)
                FROM   borrows b
                INNER  JOIN books_actual ba ON ba.id = b.books_actual_id
                WHERE  ba.books_formal_id = @id
                  AND  b.date_return IS NULL";

            using (var conn = clsDatabase.CreateOpenConnection())
            {
                using (var cmd = new SqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int borrowed = Convert.ToInt32(cmd.ExecuteScalar());
                    if (borrowed > 0) return false;
                }

                // Delete physical copies first (FK constraint), then the title
                using (var cmd = new SqlCommand(
                    "DELETE FROM books_actual WHERE books_formal_id = @id; " +
                    "DELETE FROM books_formal_authors WHERE books_formal_id = @id; " +
                    "DELETE FROM books_formal_genres  WHERE books_formal_id = @id; " +
                    "DELETE FROM books_formal WHERE id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // ── HELPERS ─────────────────────────────────────────────────────────
        private static BookFormal Map(SqlDataReader rdr) => new BookFormal
        {
            Id = Convert.ToInt32(rdr["id"]),
            Name = rdr["name"].ToString(),
            DatePublish = rdr["date_publish"] != DBNull.Value
                            ? Convert.ToDateTime(rdr["date_publish"]) : (DateTime?)null,
            ImagePath = rdr["image_path"] != DBNull.Value ? rdr["image_path"].ToString() : null,
            CopyCount = Convert.ToInt32(rdr["copy_count"])
        };
    }

    // ─── Physical copy (books_actual) ───────────────────────────────────────
    public class BookActualDAL
    {
        // ── READ ALL COPIES FOR A TITLE ─────────────────────────────────────
        public List<BookActual> GetByFormalId(int formalId)
        {
            var list = new List<BookActual>();
            const string sql = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
                FROM   books_actual ba
                INNER  JOIN books_formal bf ON bf.id = ba.books_formal_id
                WHERE  ba.books_formal_id = @fid
                ORDER  BY ba.id";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@fid", formalId);
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                        list.Add(MapActual(rdr));
            }
            return list;
        }

        // ── READ ALL ────────────────────────────────────────────────────────
        public List<BookActual> GetAll()
        {
            var list = new List<BookActual>();
            const string sql = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
                FROM   books_actual ba
                INNER  JOIN books_formal bf ON bf.id = ba.books_formal_id
                ORDER  BY bf.name, ba.id";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    list.Add(MapActual(rdr));
            return list;
        }

        // ── INSERT (add a copy) ──────────────────────────────────────────────
        public int Insert(int formalId, byte integrity)
        {
            const string sql = @"
                INSERT INTO books_actual (books_formal_id, integrity)
                VALUES (@fid, @integrity);
                SELECT SCOPE_IDENTITY();";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@fid", formalId);
                cmd.Parameters.AddWithValue("@integrity", integrity);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ── UPDATE integrity ─────────────────────────────────────────────────
        public bool UpdateIntegrity(int id, byte integrity)
        {
            const string sql = "UPDATE books_actual SET integrity = @integrity WHERE id = @id";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@integrity", integrity);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── DELETE (single copy) ─────────────────────────────────────────────
        /// <summary>Returns false if the copy is currently borrowed.</summary>
        public bool Delete(int id)
        {
            const string check = @"
                SELECT COUNT(*) FROM borrows
                WHERE books_actual_id = @id AND date_return IS NULL";

            using (var conn = clsDatabase.CreateOpenConnection())
            {
                using (var cmd = new SqlCommand(check, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return false;
                }
                using (var cmd = new SqlCommand("DELETE FROM books_actual WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Existing methods kept intact ──────────────────────────────────────
        public List<BookActual> GetAvailableBooks()
        {
            var books = new List<BookActual>();
            const string query = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
                FROM   books_actual ba
                INNER  JOIN books_formal bf ON ba.books_formal_id = bf.id
                WHERE  ba.id NOT IN (SELECT books_actual_id FROM borrows WHERE date_return IS NULL)
                ORDER  BY bf.name, ba.id";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    books.Add(MapActual(rdr));
            return books;
        }

        public List<BookActual> GetBorrowedBooks()
        {
            var books = new List<BookActual>();
            const string query = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
                FROM   books_actual ba
                INNER  JOIN books_formal bf ON ba.books_formal_id = bf.id
                WHERE  ba.id IN (SELECT books_actual_id FROM borrows WHERE date_return IS NULL)
                ORDER  BY bf.name, ba.id";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    books.Add(MapActual(rdr));
            return books;
        }

        public List<BookActual> GetBorrowedBooksByReader(int readerId)
        {
            var books = new List<BookActual>();
            const string query = @"
                SELECT ba.id, ba.books_formal_id, ba.date_create, ba.integrity, bf.name AS formal_name
                FROM   books_actual ba
                INNER  JOIN books_formal bf ON ba.books_formal_id = bf.id
                WHERE  ba.id IN (SELECT books_actual_id FROM borrows WHERE date_return IS NULL AND readers_id = @readerId)
                ORDER  BY bf.name, ba.id";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@readerId", readerId);
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                        books.Add(MapActual(rdr));
            }
            return books;
        }

        public bool ReturnBook(int bookId)
        {
            const string query = @"
                UPDATE borrows SET date_return = GETDATE()
                WHERE books_actual_id = @bookId AND date_return IS NULL";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@bookId", bookId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool IssueBook(int readerId, int bookId, int employeeId, DateTime expireDate)
        {
            const string query = @"
                INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
                VALUES (@readerId, @bookId, @employeeId, GETDATE(), @expireDate, NULL)";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@readerId", readerId);
                cmd.Parameters.AddWithValue("@bookId", bookId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@expireDate", expireDate);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private static BookActual MapActual(SqlDataReader rdr) => new BookActual
        {
            Id = Convert.ToInt32(rdr["id"]),
            FormalId = Convert.ToInt32(rdr["books_formal_id"]),
            DateCreate = Convert.ToDateTime(rdr["date_create"]),
            Integrity = Convert.ToByte(rdr["integrity"]),
            FormalName = rdr["formal_name"].ToString()
        };
    }
}