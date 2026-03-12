using System;

namespace LibraryManagement.BLL
{
    /// <summary>
    /// Encapsulates the result of an authentication operation (Login/Register).
    /// Prevents the need to throw generic Exceptions for validation failures.
    /// </summary>
    public class AuthValidationResult<T>
    {
        public bool Success { get; }
        public string ErrorMessage { get; }
        public T Data { get; }

        private AuthValidationResult(bool success, string errorMessage, T data)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public static AuthValidationResult<T> Ok(T data)
        {
            return new AuthValidationResult<T>(true, string.Empty, data);
        }

        public static AuthValidationResult<T> Fail(string errorMessage)
        {
            return new AuthValidationResult<T>(false, errorMessage, default(T));
        }
    }
}
