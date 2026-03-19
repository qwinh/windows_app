using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LibraryManagement.DAL;
using LibraryManagement.Models;

namespace LibraryManagement.BLL
{
    public class ReaderService
    {
        private readonly ReaderDAL _dal;

        public ReaderService()
        {
            _dal = new ReaderDAL();
        }

        public List<Reader> GetAllActiveReaders() => _dal.GetAllActiveReaders();

        public List<Reader> GetAll() => _dal.GetAll();
        public Reader GetById(int id) => _dal.GetById(id);

        // expiredOnly: null = all, true = expired, false = active
        public List<Reader> Search(string keyword, bool? expiredOnly = null)
            => _dal.Search(keyword != null ? keyword.Trim() : "", expiredOnly);

        // Validate then insert
        public (bool ok, string error) Add(Reader r)
        {
            string err = Validate(r);
            if (err != null) return (false, err);
            _dal.Add(r);
            return (true, null);
        }

        // Validate then update
        public (bool ok, string error) Update(Reader r)
        {
            string err = Validate(r);
            if (err != null) return (false, err);
            return _dal.Update(r) ? (true, null) : (false, "Reader not found.");
        }

        // Block deletion if borrow records exist
        public (bool ok, string error) Delete(int id)
        {
            if (_dal.HasBorrowRecords(id))
                return (false, "Cannot delete — this reader has existing borrow records.");
            return _dal.Delete(id) ? (true, null) : (false, "Reader not found.");
        }

        // Returns null if valid, otherwise error message
        private static string Validate(Reader r)
        {
            if (string.IsNullOrWhiteSpace(r.Name))
                return "Name is required.";

            if (r.Name.Trim().Length < 2)
                return "Name must be at least 2 characters.";

            if (!string.IsNullOrWhiteSpace(r.Phone) &&
                !Regex.IsMatch(r.Phone.Trim(), @"^[0-9+\-\s]{7,20}$"))
                return "Phone number is invalid.";

            if (!string.IsNullOrWhiteSpace(r.Email) &&
                !Regex.IsMatch(r.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email address is invalid.";

            if (r.Integrity < 1 || r.Integrity > 5)
                return "Integrity must be between 1 and 5.";

            return null;
        }
    }
}