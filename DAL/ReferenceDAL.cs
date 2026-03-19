using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryManagement.Helpers;
using LibraryManagement.Models;

namespace LibraryManagement.DAL
{
    public class ReferenceDAL
    {
        public List<Author> GetAllAuthors()
        {
            var list = new List<Author>();
            const string sql = "SELECT id, name FROM authors ORDER BY name";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                {
                    list.Add(new Author
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Name = rdr["name"].ToString()
                    });
                }
            return list;
        }

        public List<Genre> GetAllGenres()
        {
            var list = new List<Genre>();
            const string sql = "SELECT id, name FROM genres ORDER BY name";
            using (var conn = clsDatabase.CreateOpenConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var rdr = cmd.ExecuteReader())
                while (rdr.Read())
                {
                    list.Add(new Genre
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Name = rdr["name"].ToString()
                    });
                }
            return list;
        }
    }
}
