using System;
using System.Data.SqlClient;

namespace LibraryManagement.Helpers
{
    class clsDatabase
    {
        public static SqlConnection con;

        public static bool OpenConnection()
        {
            try
            {
                con = new SqlConnection(
                    "Server=DESKTOP-LQE3B7F\\SQLEXPRESS;" +
                    "Database=library;" +
                    "Integrated Security=True;");
                con.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
