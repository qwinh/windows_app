using System;

namespace LibraryManagement.BLL
{
    /// <summary>
    /// FEATURE: Thrown when a supplied password does not match the stored hash.
    /// </summary>
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("The supplied password is incorrect.") { }

        public InvalidPasswordException(string message)
            : base(message) { }

        public InvalidPasswordException(string message, Exception inner)
            : base(message, inner) { }
    }
}
