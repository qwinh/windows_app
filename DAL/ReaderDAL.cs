using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryManagement.Helpers;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class ReaderDAL
    {
        // ── READ ALL (active = not expired) ─────────────────────────────────
        public List<Reader> GetAllActiveReaders()
        {
            var readers = new List<Reader>();
            const string sql =
                "SELECT id, name, email, phone, address, date_create, date_expire, integrity " +
                "FROM readers WHERE date_expire > GETDATE() ORDER BY name";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    readers.Add(Map(rdr));
            return readers;
        }

        // ── READ ALL (including expired) ─────────────────────────────────────
        public List<Reader> GetAll()
        {
            var readers = new List<Reader>();
            const string sql =
                "SELECT id, name, email, phone, address, date_create, date_expire, integrity " +
                "FROM readers ORDER BY name";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                    readers.Add(Map(rdr));
            return readers;
        }

        // ── SEARCH ───────────────────────────────────────────────────────────
        public List<Reader> Search(string keyword)
        {
            var readers = new List<Reader>();
            const string sql =
                "SELECT id, name, email, phone, address, date_create, date_expire, integrity " +
                "FROM readers " +
                "WHERE name LIKE @kw OR email LIKE @kw OR phone LIKE @kw " +
                "ORDER BY name";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                        readers.Add(Map(rdr));
            }
            return readers;
        }

        // ── INSERT ───────────────────────────────────────────────────────────
        /// <summary>Inserts a new reader. Returns the new ID.</summary>
        public int Insert(Reader reader)
        {
            const string sql = @"
                INSERT INTO readers (name, email, phone, address, date_expire, integrity)
                VALUES (@name, @email, @phone, @address, @expire, @integrity);
                SELECT SCOPE_IDENTITY();";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                BindParams(cmd, reader);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ── UPDATE ───────────────────────────────────────────────────────────
        public bool Update(Reader reader)
        {
            const string sql = @"
                UPDATE readers
                SET  name        = @name,
                     email       = @email,
                     phone       = @phone,
                     address     = @address,
                     date_expire = @expire,
                     integrity   = @integrity
                WHERE id = @id";

            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                BindParams(cmd, reader);
                cmd.Parameters.AddWithValue("@id", reader.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── DELETE ───────────────────────────────────────────────────────────
        /// <summary>Returns false if the reader still has unreturned books.</summary>
        public bool Delete(int id)
        {
            const string check =
                "SELECT COUNT(*) FROM borrows WHERE readers_id = @id AND date_return IS NULL";

            using (var conn = clsDatabase.CreateOpenConnection())
            {
                using (var cmd = new SqlCommand(check, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return false;
                }
                using (var cmd = new SqlCommand("DELETE FROM readers WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // ── RENEW membership ─────────────────────────────────────────────────
        public bool RenewMembership(int id, DateTime newExpire)
        {
            const string sql = "UPDATE readers SET date_expire = @exp WHERE id = @id";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@exp", newExpire);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ── HELPERS ──────────────────────────────────────────────────────────
        private static void BindParams(SqlCommand cmd, Reader r)
        {
            cmd.Parameters.AddWithValue("@name", r.Name);
            cmd.Parameters.AddWithValue("@email", (object)r.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object)r.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@address", (object)r.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@expire", (object)r.DateExpire ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@integrity", r.Integrity);
        }

        private static Reader Map(SqlDataReader rdr) => new Reader
        {
            Id = Convert.ToInt32(rdr["id"]),
            Name = rdr["name"].ToString(),
            Email = rdr["email"] != DBNull.Value ? rdr["email"].ToString() : null,
            Phone = rdr["phone"] != DBNull.Value ? rdr["phone"].ToString() : null,
            Address = rdr["address"] != DBNull.Value ? rdr["address"].ToString() : null,
            DateCreate = Convert.ToDateTime(rdr["date_create"]),
            DateExpire = rdr["date_expire"] != DBNull.Value
                            ? Convert.ToDateTime(rdr["date_expire"]) : (DateTime?)null,
            Integrity = Convert.ToByte(rdr["integrity"])
        };
    }
}