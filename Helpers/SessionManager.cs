using System.Data.SqlClient;
using LibraryManagement.Models;

namespace LibraryManagement.Helpers
{
    public static class SessionManager
    {
        public static Employee CurrentEmployee { get; private set; }

        private static SqlConnection _lockConnection;

        public static SqlConnection LockConnection => _lockConnection;

        public static void SetSession(Employee employee, SqlConnection lockConnection)
        {
            CurrentEmployee = employee;
            _lockConnection = lockConnection;
        }

        public static void Logout()
        {
            if (_lockConnection != null)
            {
                _lockConnection.Close();
                _lockConnection.Dispose();
                _lockConnection = null;
            }
            CurrentEmployee = null;
        }
        public static bool IsLoggedIn => CurrentEmployee != null;
    }
}
