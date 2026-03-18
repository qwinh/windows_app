using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.DAL;
using LibraryManagement.BLL;

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
                // In a true enterprise app, this EmployeeID comes from caching/session of the logged-in user.
                // For now, we will default to 1 (Assuming Admin/First setup user is Employee 1)
                int currentEmployeeId = 1; 
                
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

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            // Soft border color #E2E8F0
            using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            }
        }
    }
}
