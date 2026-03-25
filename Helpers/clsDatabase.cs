using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryManagement.Helpers
{
    public static class clsDatabase
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

        public static SqlConnection CreateOpenConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static bool TestConnection()
        {
            try
            {
                using (CreateOpenConnection()) { }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
