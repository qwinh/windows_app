using System.Data.SqlClient;
using LibraryManagement.Models;

namespace LibraryManagement.Helpers
{
    /// <summary>
    /// Holds the currently-logged-in employee and the dedicated SqlConnection
    /// whose existence keeps the sp_getapplock Session-scoped lock alive.
    ///
    /// Rules:
    ///   - SetSession() is called ONLY by AuthService after a successful login lock.
    ///   - Logout() is called on explicit logout AND on MainMenu.FormClosing.
    ///   - _lockConnection must NEVER be used for regular queries — it exists solely
    ///     to keep the sp_getapplock lock open.
    /// </summary>
    public static class SessionManager
    {
        public static Employee CurrentEmployee { get; private set; }

        private static SqlConnection _lockConnection;

        /// <summary>
        /// Exposed so UserDAL.AcquireLoginLock can execute sp_getapplock on it.
        /// Do NOT use this for normal queries.
        /// </summary>
        public static SqlConnection LockConnection => _lockConnection;

        /// <summary>
        /// Called by AuthService immediately after sp_getapplock succeeds.
        /// Stores the employee and the open lock connection for the lifetime of the session.
        /// </summary>
        public static void SetSession(Employee employee, SqlConnection lockConnection)
        {
            CurrentEmployee = employee;
            _lockConnection = lockConnection;
        }

        /// <summary>
        /// Clears the session. Closing the lock connection automatically releases
        /// the Session-scoped sp_getapplock on SQL Server — no explicit sp_releaseapplock needed.
        /// </summary>
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

        /// <summary>Returns true when an employee is currently logged in.</summary>
        public static bool IsLoggedIn => CurrentEmployee != null;
    }
}
