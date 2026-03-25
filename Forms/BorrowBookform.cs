using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.DAL;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class BorrowBookform : Form
    {
        private readonly ReaderDAL _readerDal;
        private readonly BookActualDAL _bookDal;
        private readonly BorrowService _borrowService;
        
        public BorrowBookform()
        {
            InitializeComponent();
            
            _readerDal = new ReaderDAL();
            _bookDal = new BookActualDAL();
            _borrowService = new BorrowService();

            // Setup default properties for datetime picker
            dtpDateExpire.MinDate = DateTime.Today;            // Cannot set a due date in the past
            dtpDateExpire.Value = DateTime.Today.AddDays(14);  // Default return duration (e.g., 2 weeks)
            
            // Center the card on resize
            this.Resize += (_, __) => CenterCard();
        }

        private void CenterCard()
        {
            if (pnlBorrowCard != null)
            {
                pnlBorrowCard.Left = (this.ClientSize.Width - pnlBorrowCard.Width) / 2;
                pnlBorrowCard.Top = (this.ClientSize.Height - pnlBorrowCard.Height) / 2;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CenterCard();
            
            // Hover effects for Submit button
            AttachHoverEffect(btnSubmit, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
            
            // Cancel button hover text color
            btnCancel.MouseEnter += (_, __) => btnCancel.ForeColor = Color.FromArgb(29, 78, 216);
            btnCancel.MouseLeave += (_, __) => btnCancel.ForeColor = Color.FromArgb(120, 130, 145);
            
            // Load real database data into the dropdowns
            LoadComboBoxData();
        }
        
        private void LoadComboBoxData()
        {
            try
            {
                // 1. Load Readers
                var readers = _readerDal.GetAllActiveReaders();
                
                // Set DataSource to link hidden IDs
                cmbReader.DataSource = readers;
                cmbReader.DisplayMember = "DisplayName"; // Maps to "Alice Brown (1)"
                cmbReader.ValueMember = "Id";            // Maps to Primary Key
                
                // Configure strictly typed Autocomplete searching against the exact data pool
                var readerSource = new AutoCompleteStringCollection();
                readerSource.AddRange(readers.Select(r => r.DisplayName).ToArray());
                cmbReader.AutoCompleteCustomSource = readerSource;
                cmbReader.SelectedIndex = -1; // Keep it blank initially

                // 2. Load Books
                var books = _bookDal.GetAvailableBooks();
                
                // Set DataSource to link hidden IDs
                cmbBook.DataSource = books;
                cmbBook.DisplayMember = "DisplayTitle";  // Maps to "Clean Code (Copy 102)"
                cmbBook.ValueMember = "Id";              // Maps to Primary Key

                // Configure strictly typed Autocomplete searching against the exact data pool
                var bookSource = new AutoCompleteStringCollection();
                bookSource.AddRange(books.Select(b => b.DisplayTitle).ToArray());
                cmbBook.AutoCompleteCustomSource = bookSource;
                cmbBook.SelectedIndex = -1; // Keep it blank initially
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void AttachHoverEffect(Button btn, Color hoverColor, Color normalColor)
        {
            btn.MouseEnter += (_, __) => btn.BackColor = hoverColor;
            btn.MouseLeave += (_, __) => btn.BackColor = normalColor;
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
                
                // Adjust font size dynamically based on width or just explicitly smaller (9f)
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
                lblReaderPhoneValue.Text = string.IsNullOrEmpty(selectedReader.Phone) ? "Phone: No Phone" : $"Phone: {selectedReader.Phone}";
                lblReaderAddressValue.Text = string.IsNullOrEmpty(selectedReader.Address) ? "Address: No Address" : $"Address: {selectedReader.Address}";
                
                if (!string.IsNullOrEmpty(selectedReader.ImagePath) && System.IO.File.Exists(selectedReader.ImagePath))
                {
                    pbReaderAvatar.ImageLocation = selectedReader.ImagePath;
                }
                else
                {
                    DrawNoImage(pbReaderAvatar, "No Image");
                }
            }
            else
            {
                if (lblReaderNameValue != null) lblReaderNameValue.Text = "Reader Name";
                if (lblReaderPhoneValue != null) lblReaderPhoneValue.Text = "Phone: ";
                if (lblReaderAddressValue != null) lblReaderAddressValue.Text = "Address: ";
                if (pbReaderAvatar != null) DrawNoImage(pbReaderAvatar, "No Image");
            }
        }

        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBook.SelectedItem is BookActual selectedBook)
            {
                lblBookAuthorValue.Text = string.IsNullOrEmpty(selectedBook.AuthorName) ? "Unknown Author" : selectedBook.AuthorName;
                
                // Display book copy integrity (1-5 scale)
                lblBookIntegrityValue.Text = $"Integrity: {selectedBook.Integrity}";
                
                if (!string.IsNullOrEmpty(selectedBook.ImagePath) && System.IO.File.Exists(selectedBook.ImagePath))
                {
                    pbBookCover.ImageLocation = selectedBook.ImagePath;
                }
                else
                {
                    DrawNoImage(pbBookCover, "No Cover");
                }
            }
            else
            {
                if (lblBookAuthorValue != null) lblBookAuthorValue.Text = "Author Name";
                if (lblBookIntegrityValue != null) lblBookIntegrityValue.Text = "Integrity: ";
                if (pbBookCover != null) DrawNoImage(pbBookCover, "No Cover");
            }
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Simple validation
            if (cmbReader.SelectedValue == null || cmbBook.SelectedValue == null)
            {
                MessageBox.Show("Please select both a valid Reader and a Book from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int readerId = (int)cmbReader.SelectedValue;
            int bookId = (int)cmbBook.SelectedValue;

            // Expected return date matches 'date_expire' in borrows table
            DateTime dateExpire = dtpDateExpire.Value;

            try
            {
                // Get the EmployeeID from the active session
                int currentEmployeeId = LibraryManagement.Helpers.SessionManager.CurrentEmployee?.Id ?? 1; 
                
                bool success = _borrowService.IssueBook(readerId, bookId, currentEmployeeId, dateExpire);
                
                if (success)
                {
                    MessageBox.Show($"Book Copy '{cmbBook.Text}' has been successfully issued to '{cmbReader.Text}'.\nReturn Date: {dateExpire.ToShortDateString()}", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Re-load the data so the actively borrowed book disappears from the options!
                    LoadComboBoxData();
                    
                    // Clear the visual text manually
                    cmbReader.Text = string.Empty;
                    cmbBook.Text = string.Empty;
                }
                else
                {
                     MessageBox.Show("Failed to record the borrow transaction in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database/Business Logic Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
