using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            AttachHoverEffect(btnSubmit, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
            
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

        private void DrawNoImage(PictureBox pb, string text = "No Image")
        {
            if (pb == null) return;
            
            pb.ImageLocation = null; // Clear any asynchronous image loading
            
            int w = pb.Width > 0 ? pb.Width : 150;
            int h = pb.Height > 0 ? pb.Height : 200;
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(218, 222, 236));
                g.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Adjust font size dynamically based on width or explicit smaller size
                float fontSize = w < 80 ? 8f : 10f; 
                using (Font f = new Font("Segoe UI", fontSize, FontStyle.Bold))
                using (SolidBrush br = new SolidBrush(Color.FromArgb(140, 150, 175)))
                {
                    g.TranslateTransform(w / 2f, h / 2f);
                    g.RotateTransform(-45);
                    SizeF sz = g.MeasureString(text, f);
                    g.DrawString(text, f, br, -sz.Width / 2f, -sz.Height / 2f);
                    g.ResetTransform();
                }
            }
            pb.Image = bmp;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void cmbReader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReader.SelectedItem is Reader selectedReader)
            {
                lblReaderNameValue.Text = selectedReader.Name;
                lblReaderPhoneValue.Text = string.IsNullOrEmpty(selectedReader.Phone) ? "No Phone" : selectedReader.Phone;
                lblReaderAddressValue.Text = string.IsNullOrEmpty(selectedReader.Address) ? "No Address" : selectedReader.Address;
                
                if (!string.IsNullOrEmpty(selectedReader.ImagePath) && System.IO.File.Exists(selectedReader.ImagePath))
                {
                    pbReaderAvatar.ImageLocation = selectedReader.ImagePath;
                }
                else
                {
                    DrawNoImage(pbReaderAvatar, "No Image");
                }
                
                var readerBooks = _bookDal.GetBorrowedBooksByReader(selectedReader.Id);
                BindBooksToCombo(readerBooks);
            }
            else
            {
                if (lblReaderNameValue != null) lblReaderNameValue.Text = "Reader Name";
                if (lblReaderPhoneValue != null) lblReaderPhoneValue.Text = "Phone";
                if (lblReaderAddressValue != null) lblReaderAddressValue.Text = "Address";
                if (pbReaderAvatar != null) DrawNoImage(pbReaderAvatar, "No Image");

                // If nothing is selected or it's cleared, show all borrowed books
                if (_allBorrowedBooks != null)
                {
                    BindBooksToCombo(_allBorrowedBooks);
                }
            }
            
            // Clear the text explicitly to prevent carrying over old visual selection
            if (cmbBook != null)
            {
                cmbBook.Text = string.Empty;
                cmbBook_SelectedIndexChanged(null, null); // forcefully clear the info
            }
        }

        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBook != null && cmbBook.SelectedItem is BookActual selectedBook)
            {
                if (lblBookAuthorValue != null)
                {
                    lblBookAuthorValue.Text = string.IsNullOrEmpty(selectedBook.AuthorName) ? "Unknown Author" : selectedBook.AuthorName;
                }
                
                if (lblReturnStatusValue != null)
                {
                    if (selectedBook.DateExpire.HasValue)
                    {
                        if (selectedBook.DateExpire.Value.Date < DateTime.Now.Date)
                        {
                            lblReturnStatusValue.Text = "Return Late";
                            lblReturnStatusValue.ForeColor = Color.FromArgb(220, 38, 38); // Red
                        }
                        else
                        {
                            lblReturnStatusValue.Text = "On Time";
                            lblReturnStatusValue.ForeColor = Color.FromArgb(16, 185, 129); // Green
                        }
                    }
                    else
                    {
                        lblReturnStatusValue.Text = "Unknown";
                        lblReturnStatusValue.ForeColor = Color.FromArgb(100, 110, 120);
                    }
                }
                
                if (pbBookCover != null)
                {
                    if (!string.IsNullOrEmpty(selectedBook.ImagePath) && System.IO.File.Exists(selectedBook.ImagePath))
                    {
                        pbBookCover.ImageLocation = selectedBook.ImagePath;
                    }
                    else
                    {
                        DrawNoImage(pbBookCover, "No Cover");
                    }
                }
            }
            else
            {
                if (lblBookAuthorValue != null) lblBookAuthorValue.Text = "Author Name";
                if (lblReturnStatusValue != null) lblReturnStatusValue.Text = "";
                if (pbBookCover != null) DrawNoImage(pbBookCover, "No Cover");
            }
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
