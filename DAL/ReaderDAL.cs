using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryManagement.Helpers;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class ReaderDAL
    {
        public List<Reader> GetAllActiveReaders()
        {
            var readers = new List<Reader>();
            string query = "SELECT id, name, email, phone, address, date_create, date_expire, integrity, image_path " +
                           "FROM readers WHERE date_expire > GETDATE()";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    readers.Add(new Reader
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : null,
                        Phone = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : null,
                        Address = reader["address"] != DBNull.Value ? reader["address"].ToString() : null,
                        DateCreate = Convert.ToDateTime(reader["date_create"]),
                        DateExpire = reader["date_expire"] != DBNull.Value ? Convert.ToDateTime(reader["date_expire"]) : (DateTime?)null,
                        Integrity = Convert.ToByte(reader["integrity"]),
                        ImagePath = reader["image_path"] != DBNull.Value ? reader["image_path"].ToString() : null
                    });
                }
            }
            return readers;
        }


        // Get all readers (active + expired)
        public List<Reader> GetAll()
        {
            var list = new List<Reader>();
            string query = "SELECT id, name, email, phone, address, date_create, date_expire, integrity, image_path FROM readers ORDER BY name";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read()) list.Add(MapRow(r));
            }
            return list;
        }

        // Get one reader by ID
        public Reader GetById(int id)
        {
            string query = "SELECT id, name, email, phone, address, date_create, date_expire, integrity, image_path FROM readers WHERE id = @id";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    return r.Read() ? MapRow(r) : null;
                }
            }
        }

        // Search by name / phone / email, filter by expiry: null=all, true=expired, false=active
        public List<Reader> Search(string keyword, bool? expiredOnly)
        {
            var list = new List<Reader>();
            string query = @"SELECT id, name, email, phone, address, date_create, date_expire, integrity, image_path
                             FROM readers
                             WHERE (name LIKE @kw OR phone LIKE @kw OR email LIKE @kw)
                               AND (@all = 1
                                    OR (@exp = 1 AND (date_expire < GETDATE() OR date_expire IS NULL))
                                    OR (@exp = 0 AND date_expire >= GETDATE()))
                             ORDER BY name";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                cmd.Parameters.AddWithValue("@all", expiredOnly == null ? 1 : 0);
                cmd.Parameters.AddWithValue("@exp", expiredOnly == true ? 1 : 0);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(MapRow(r));
                }
            }
            return list;
        }

        // Insert new reader, returns new ID
        public int Add(Reader reader)
        {
            string query = @"INSERT INTO readers (name, email, phone, address, date_expire, integrity, image_path)
                             VALUES (@name, @email, @phone, @address, @date_expire, @integrity, @image_path);
                             SELECT SCOPE_IDENTITY();";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                BindParams(cmd, reader);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Update reader info
        public bool Update(Reader reader)
        {
            string query = @"UPDATE readers SET
                                name        = @name,
                                email       = @email,
                                phone       = @phone,
                                address     = @address,
                                date_expire = @date_expire,
                                integrity   = @integrity,
                                image_path  = @image_path
                             WHERE id = @id";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                BindParams(cmd, reader);
                cmd.Parameters.AddWithValue("@id", reader.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Delete reader by ID
        public bool Delete(int id)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand("DELETE FROM readers WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Check if reader has borrow records — block deletion if true
        public bool HasBorrowRecords(int readerId)
        {
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM borrows WHERE readers_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", readerId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Map a row to Reader object
        private static Reader MapRow(SqlDataReader r)
        {
            return new Reader
            {
                Id = r.GetInt32(r.GetOrdinal("id")),
                Name = r["name"].ToString(),
                Email = r["email"] == DBNull.Value ? null : r["email"].ToString(),
                Phone = r["phone"] == DBNull.Value ? null : r["phone"].ToString(),
                Address = r["address"] == DBNull.Value ? null : r["address"].ToString(),
                DateCreate = Convert.ToDateTime(r["date_create"]),
                DateExpire = r["date_expire"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["date_expire"]),
                Integrity = Convert.ToByte(r["integrity"]),
                ImagePath = r["image_path"] == DBNull.Value ? null : r["image_path"].ToString()
            };
        }

        // Shared params for Add / Update
        private static void BindParams(SqlCommand cmd, Reader reader)
        {
            cmd.Parameters.AddWithValue("@name", reader.Name);
            cmd.Parameters.AddWithValue("@email", (object)reader.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object)reader.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@address", (object)reader.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@date_expire", (object)reader.DateExpire ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@integrity", reader.Integrity);
            cmd.Parameters.AddWithValue("@image_path", (object)reader.ImagePath ?? DBNull.Value);
        }
    }
}