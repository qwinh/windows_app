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
            
            // Assuming active readers are those whose date_expire is in the future
            string query = "SELECT id, name, email, phone, address, date_create, date_expire, integrity " +
                           "FROM readers WHERE date_expire > GETDATE()";
                           
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
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
                            Integrity = Convert.ToByte(reader["integrity"])
                        });
                    }
                }
            }
            
            return readers;
        }
    }
}
