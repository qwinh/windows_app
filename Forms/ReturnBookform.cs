using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using LibraryManagement.DAL;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class ReturnBookform : Form
    {
        private readonly ReaderDAL _readerDal;
        private readonly BookActualDAL _bookDal;
        private readonly BorrowService _borrowService;
        private List<BookActual> _allBorrowedBooks;

        public ReturnBookform()
        {
            InitializeComponent();
            
            _readerDal = new ReaderDAL();
            _bookDal = new BookActualDAL();
            _borrowService = new BorrowService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // Hover effects for Submit button (Green for return)
            AttachHoverEffect(btnSubmit, Color.FromArgb(5, 150, 105), Color.FromArgb(16, 185, 129));
            
            // Cancel button hover text color
            btnCancel.MouseEnter += (_, __) => btnCancel.ForeColor = Color.FromArgb(16, 185, 129);
            btnCancel.MouseLeave += (_, __) => btnCancel.ForeColor = Color.FromArgb(120, 130, 145);
            
            LoadComboBoxData();
        }
        
        private void LoadComboBoxData()
        {
            try
            {
                // 1. Load Readers
                var readers = _readerDal.GetAllActiveReaders();
                
                cmbReader.DataSource = readers;
                cmbReader.DisplayMember = "DisplayName"; 
                cmbReader.ValueMember = "Id";            
                
                var readerSource = new AutoCompleteStringCollection();
                readerSource.AddRange(readers.Select(r => r.DisplayName).ToArray());
                cmbReader.AutoCompleteCustomSource = readerSource;
                cmbReader.SelectedIndex = -1;

                // 2. Load Borrowed Books into memory
                _allBorrowedBooks = _bookDal.GetBorrowedBooks();
                
                // Initially show all borrowed books
                BindBooksToCombo(_allBorrowedBooks);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindBooksToCombo(List<BookActual> books)
        {
            cmbBook.DataSource = books.ToList(); // clone list to ensure refresh
            cmbBook.DisplayMember = "DisplayTitle";
            cmbBook.ValueMember = "Id";

            var bookSource = new AutoCompleteStringCollection();
            bookSource.AddRange(books.Select(b => b.DisplayTitle).ToArray());
            cmbBook.AutoCompleteCustomSource = bookSource;
            cmbBook.SelectedIndex = -1;
        }

        private void cmbReader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReader.SelectedValue != null && cmbReader.SelectedValue is int readerId)
            {
                var readerBooks = _bookDal.GetBorrowedBooksByReader(readerId);
                BindBooksToCombo(readerBooks);
            }
            else
            {
                // If nothing is selected or it's cleared, show all borrowed books
                if (_allBorrowedBooks != null)
                {
                    BindBooksToCombo(_allBorrowedBooks);
                }
            }
            
            // Clear the text explicitly to prevent carrying over old visual selection
            cmbBook.Text = string.Empty;
        }

        private static void AttachHoverEffect(Button btn, Color hoverColor, Color normalColor)
        {
            btn.MouseEnter += (_, __) => btn.BackColor = hoverColor;
            btn.MouseLeave += (_, __) => btn.BackColor = normalColor;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbReader.SelectedValue == null || cmbBook.SelectedValue == null)
            {
                MessageBox.Show("Please select both a valid Reader and the Borrowed Book.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int readerId = (int)cmbReader.SelectedValue;
            int bookId = (int)cmbBook.SelectedValue;
            
            try
            {
                bool success = _borrowService.ReturnBook(bookId);
                
                if (success)
                {
                    MessageBox.Show($"Book Copy '{cmbBook.Text}' has been successfully returned.", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    // Re-load the data 
                    LoadComboBoxData();
                    
                    cmbBook.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Could not find an active borrow record for this book.", "Return Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            }
        }
    }
}
