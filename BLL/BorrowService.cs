using System;
using LibraryManagement.DAL;

namespace LibraryManagement.BLL
{
    public class BorrowService
    {
        private readonly BookActualDAL _bookDal;

        public BorrowService()
        {
            _bookDal = new BookActualDAL();
        }

        public bool IssueBook(int readerId, int bookId, int employeeId, DateTime expireDate)
        {
            if (expireDate <= DateTime.Now)
            {
                throw new Exception("Return date must be in the future.");
            }
            
            return _bookDal.IssueBook(readerId, bookId, employeeId, expireDate);
        }

        public bool ReturnBook(int bookId)
        {
            return _bookDal.ReturnBook(bookId);
        }
    }
}
