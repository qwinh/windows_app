using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.DAL;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class CrudBookForm : Form
    {
        private BookFormalDAL _dal;
        private BookActualDAL _copyDal;
        private List<BookFormal> _allBooks;
        private int _currentBookId = 0;

        public CrudBookForm()
        {
            InitializeComponent();
            _dal = new BookFormalDAL();
            _copyDal = new BookActualDAL();
            
            this.Load += CrudBookForm_Load;
            
            // Wire events
            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnBrowse.Click += BtnBrowse_Click;
            dataGridViewBooks.SelectionChanged += DataGridViewBooks_SelectionChanged;
            
            btnAddCopy.Click += BtnAddCopy_Click;
            btnUpdateCopy.Click += BtnUpdateCopy_Click;
            btnDeleteCopy.Click += BtnDeleteCopy_Click;
        }

        private void CrudBookForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadData();
            ClearInputs();
            
            // Format DataGridView
            dataGridViewBooks.AutoGenerateColumns = false;
            dataGridViewBooks.Columns.Clear();
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Title", FillWeight = 160 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AuthorName", HeaderText = "Author", FillWeight = 140 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalCopies", HeaderText = "Total", FillWeight = 50 });
            dataGridViewBooks.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AvailableCopies", HeaderText = "Avail", FillWeight = 50 });

            // Format Copies DataGridView
            dgvCopies.AutoGenerateColumns = false;
            dgvCopies.Columns.Clear();
            dgvCopies.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Copy ID", FillWeight = 60 });
            dgvCopies.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Integrity", HeaderText = "Intg", FillWeight = 40 });
            dgvCopies.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatusDisplay", HeaderText = "Status", FillWeight = 100 });
        }

        private void LoadDropdowns()
        {
            // Load Authors
            var authors = _dal.GetAuthors();
            authors.Insert(0, new Author { Id = 0, Name = "-- Select Author --" });
            cmbAuthor.DataSource = authors;
            cmbAuthor.DisplayMember = "Name";
            cmbAuthor.ValueMember = "Id";

            // Load Genres
            var genres = _dal.GetGenres();
            genres.Insert(0, new Genre { Id = 0, Name = "-- Select Genre --" });
            cmbGenre.DataSource = genres;
            cmbGenre.DisplayMember = "Name";
            cmbGenre.ValueMember = "Id";
        }

        private void LoadData()
        {
            _allBooks = _dal.GetAllBooksFormal();
            FilterList();
        }

        private void FilterList()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dataGridViewBooks.DataSource = _allBooks;
            }
            else
            {
                dataGridViewBooks.DataSource = _allBooks.Where(b => 
                    b.Name.ToLower().Contains(keyword) || 
                    (b.AuthorName != null && b.AuthorName.ToLower().Contains(keyword)) ||
                    (b.GenreName != null && b.GenreName.ToLower().Contains(keyword))
                ).ToList();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e) => FilterList();

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                FilterList();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearInputs();
            _currentBookId = 0;
            lblDetailsTitle.Text = "Add New Book";
            dataGridViewBooks.ClearSelection();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_currentBookId == 0)
            {
                // If it's a new book currently being created, we can just treat it as a clear/cancel
                ClearInputs();
                lblDetailsTitle.Text = "Add New Book";
                dataGridViewBooks.ClearSelection();
                return;
            }

            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this book?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                bool success = _dal.DeleteBook(_currentBookId);
                if (success)
                {
                    MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    BtnAdd_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed to delete the book. It may be borrowed by a reader.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            cmbAuthor.SelectedIndex = 0;
            cmbGenre.SelectedIndex = 0;
            dtpDatePublish.Value = DateTime.Today;
            txtImagePath.Text = "";
            pbCover.Image = null;
            LoadCopies();
        }

        private void DataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow != null && dataGridViewBooks.CurrentRow.DataBoundItem is BookFormal book)
            {
                _currentBookId = book.Id;
                lblDetailsTitle.Text = "Edit Book";
                
                txtName.Text = book.Name;
                if (book.AuthorId > 0) cmbAuthor.SelectedValue = book.AuthorId;
                else cmbAuthor.SelectedIndex = 0;
                
                if (book.GenreId > 0) cmbGenre.SelectedValue = book.GenreId;
                else cmbGenre.SelectedIndex = 0;

                if (book.DatePublish.HasValue) dtpDatePublish.Value = book.DatePublish.Value;
                else dtpDatePublish.Value = DateTime.Today;

                txtImagePath.Text = book.ImagePath;
                LoadImage(book.ImagePath);
                
                LoadCopies();
            }
        }

        private void LoadImage(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    pbCover.Image = Image.FromFile(path);
                }
                else
                {
                    pbCover.Image = null;
                }
            }
            catch
            {
                pbCover.Image = null;
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Cover Image";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                    LoadImage(ofd.FileName);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the book title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int authorId = Convert.ToInt32(cmbAuthor.SelectedValue);
            if (authorId == 0)
            {
                MessageBox.Show("Please select an author.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int genreId = Convert.ToInt32(cmbGenre.SelectedValue);
            if (genreId == 0)
            {
                MessageBox.Show("Please select a genre.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new BookFormal
            {
                Id = _currentBookId,
                Name = txtName.Text.Trim(),
                DatePublish = dtpDatePublish.Value,
                ImagePath = txtImagePath.Text.Trim(),
                AuthorId = authorId,
                GenreId = genreId
            };

            bool success = false;
            if (_currentBookId == 0)
            {
                // Add new book
                success = _dal.AddBook(book);
            }
            else
            {
                // Update existing book
                success = _dal.UpdateBook(book);
            }

            if (success)
            {
                MessageBox.Show("Book saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                BtnAdd_Click(sender, e); // Reset to Add mode
            }
            else
            {
                MessageBox.Show("Failed to save the book. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCopies()
        {
            if (_currentBookId == 0)
            {
                dgvCopies.DataSource = null;
                return;
            }
            dgvCopies.DataSource = _copyDal.GetCopiesByFormalId(_currentBookId);
        }

        private void BtnAddCopy_Click(object sender, EventArgs e)
        {
            if (_currentBookId == 0)
            {
                MessageBox.Show("Please select a saved book first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (_copyDal.AddCopy(_currentBookId))
            {
                RefreshDataKeepSelection(_currentBookId);
            }
            else
            {
                MessageBox.Show("Failed to add a copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateCopy_Click(object sender, EventArgs e)
        {
            if (dgvCopies.CurrentRow != null && dgvCopies.CurrentRow.DataBoundItem is BookActual copy)
            {
                using (Form prompt = new Form())
                {
                    prompt.Width = 300;
                    prompt.Height = 150;
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.Text = "Update Integrity";
                    prompt.StartPosition = FormStartPosition.CenterParent;
                    prompt.MaximizeBox = false;
                    prompt.MinimizeBox = false;

                    Label textLabel = new Label() { Left = 20, Top = 25, Text = "Integrity (1-5):" };
                    NumericUpDown num = new NumericUpDown() { Left = 120, Top = 23, Width = 100, Minimum = 1, Maximum = 5, Value = copy.Integrity };
                    Button confirmation = new Button() { Text = "Save", Left = 120, Width = 100, Top = 60, DialogResult = DialogResult.OK };
                    confirmation.Click += (sender2, e2) => { prompt.Close(); };
                    
                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(num);
                    prompt.Controls.Add(confirmation);
                    prompt.AcceptButton = confirmation;
                    
                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        if (_copyDal.UpdateCopy(copy.Id, (byte)num.Value))
                        {
                            LoadCopies();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a copy to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDeleteCopy_Click(object sender, EventArgs e)
        {
            if (dgvCopies.CurrentRow != null && dgvCopies.CurrentRow.DataBoundItem is BookActual copy)
            {
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete Copy ID {copy.Id}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    if (_copyDal.DeleteCopy(copy.Id))
                    {
                        RefreshDataKeepSelection(_currentBookId);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the copy. It may be currently borrowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a copy to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshDataKeepSelection(int savedId)
        {
            dataGridViewBooks.SelectionChanged -= DataGridViewBooks_SelectionChanged;
            
            LoadData(); // Hits FilterList() and updates grid
            
            ReselectBook(savedId);
            
            dataGridViewBooks.SelectionChanged += DataGridViewBooks_SelectionChanged;
            
            _currentBookId = savedId;
            LoadCopies();
        }

        private void ReselectBook(int bookId)
        {
            foreach(DataGridViewRow row in dataGridViewBooks.Rows)
            {
                if (row.DataBoundItem is BookFormal b && b.Id == bookId)
                {
                    row.Selected = true;
                    if (dataGridViewBooks.CurrentCell != null)
                    {
                        dataGridViewBooks.CurrentCell = row.Cells[0];
                    }
                    dataGridViewBooks.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
    }
}
