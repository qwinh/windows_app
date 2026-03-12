using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryManagement.Helpers
{
    /// <summary>
    /// Connection factory. Each caller creates its own SqlConnection via
    /// CreateOpenConnection() and disposes it in a using-block.
    /// ADO.NET connection pooling makes repeated open/close efficient.
    /// </summary>
    public static class clsDatabase
    {
        /// <summary>Single source of truth for the connection string (read from App.config).</summary>
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

        /// <summary>
        /// Creates and returns a new, already-opened SqlConnection.
        /// The CALLER is responsible for closing/disposing it — always use inside a using block.
        /// </summary>
        public static SqlConnection CreateOpenConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>Quick sanity-check — returns true if the database is reachable.</summary>
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
