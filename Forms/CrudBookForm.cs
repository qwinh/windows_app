using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.DAL;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class CrudBookForm : Form
    {
        // ── Fields ───────────────────────────────────────────────────────────
        private readonly BookFormalDAL _formalDal = new BookFormalDAL();
        private readonly BookActualDAL _actualDal = new BookActualDAL();
        private readonly ReferenceDAL _refDal = new ReferenceDAL();

        private List<BookFormal> _books;           // current grid data
        private List<Author> _allAuthors;
        private List<Genre> _allGenres;
        private string _currentImagePath;
        private BookFormal _selected;        // row the user clicked
        private bool _isEditMode;      // Add vs Edit state

        // ── Constructor ──────────────────────────────────────────────────────
        public CrudBookForm()
        {
            InitializeComponent();

            this.Resize += (_, __) => CenterCard();
            AttachHoverEffects();
        }

        // ── Load ─────────────────────────────────────────────────────────────
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CenterCard();
            
            _allAuthors = _refDal.GetAllAuthors();
            _allGenres = _refDal.GetAllGenres();
            
            clbAuthors.DataSource = _allAuthors;
            clbAuthors.DisplayMember = "Name";
            clbAuthors.ValueMember = "Id";
            
            clbGenres.DataSource = _allGenres;
            clbGenres.DisplayMember = "Name";
            clbGenres.ValueMember = "Id";

            LoadGrid(string.Empty);
            SetFormState(editing: false);
        }

        // ════════════════════════════════════════════════════════════════════
        //  DATA
        // ════════════════════════════════════════════════════════════════════
        private void LoadGrid(string keyword)
        {
            try
            {
                _books = string.IsNullOrWhiteSpace(keyword)
                    ? _formalDal.GetAll()
                    : _formalDal.Search(keyword);

                dgvBooks.Rows.Clear();
                foreach (var b in _books)
                {
                    dgvBooks.Rows.Add(
                        b.Id,
                        b.Name,
                        b.DatePublish.HasValue ? b.DatePublish.Value.ToString("yyyy-MM-dd") : "—",
                        b.CopyCount
                    );
                }

                lblCount.Text = $"{_books.Count} record(s)";
            }
            catch (Exception ex)
            {
                ShowError("Error loading books: " + ex.Message);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        //  BUTTON HANDLERS
        // ════════════════════════════════════════════════════════════════════

        // ── Search ────────────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid(txtSearch.Text.Trim());
            ClearForm();
        }

        // ── Add (open form) ───────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _selected = null;
            _isEditMode = false;
            ClearForm();
            SetFormState(editing: true);
            txtName.Focus();
        }

        // ── Edit (open form with selected row) ────────────────────────────
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selected == null) { ShowWarning("Please select a book to edit."); return; }

            _isEditMode = true;
            txtName.Text = _selected.Name;
            dtpPublish.Checked = _selected.DatePublish.HasValue;
            if (_selected.DatePublish.HasValue)
                dtpPublish.Value = _selected.DatePublish.Value;

            _currentImagePath = _selected.ImagePath;
            pbImage.Image = null;
            if (!string.IsNullOrEmpty(_currentImagePath))
            {
                try { pbImage.Image = Image.FromFile(_currentImagePath); }
                catch { /* Ignore */ }
            }

            var authorIds = _formalDal.GetAuthorIds(_selected.Id);
            for (int i = 0; i < clbAuthors.Items.Count; i++)
            {
                var author = (Author)clbAuthors.Items[i];
                clbAuthors.SetItemChecked(i, authorIds.Contains(author.Id));
            }

            var genreIds = _formalDal.GetGenreIds(_selected.Id);
            for (int i = 0; i < clbGenres.Items.Count; i++)
            {
                var genre = (Genre)clbGenres.Items[i];
                clbGenres.SetItemChecked(i, genreIds.Contains(genre.Id));
            }

            SetFormState(editing: true);
            txtName.Focus();
        }

        // ── Save (Insert or Update) ────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                ShowWarning("Book title cannot be empty.");
                txtName.Focus();
                return;
            }

            try
            {
                var book = new BookFormal
                {
                    Name = name,
                    DatePublish = dtpPublish.Checked ? dtpPublish.Value.Date : (DateTime?)null,
                    ImagePath = _currentImagePath
                };

                foreach (Author a in clbAuthors.CheckedItems)
                    book.AuthorIds.Add(a.Id);
                foreach (Genre g in clbGenres.CheckedItems)
                    book.GenreIds.Add(g.Id);

                if (_isEditMode)
                {
                    book.Id = _selected.Id;
                    _formalDal.Update(book);
                    ShowInfo("Book updated successfully.");
                }
                else
                {
                    _formalDal.Insert(book);
                    ShowInfo("Book added successfully.");
                }

                SetFormState(editing: false);
                ClearForm();
                LoadGrid(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                ShowError("Save failed: " + ex.Message);
            }
        }

        // ── Delete ────────────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null) { ShowWarning("Please select a book to delete."); return; }

            var confirm = MessageBox.Show(
                $"Delete \"{_selected.Name}\" and all its physical copies?\nThis cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = _formalDal.Delete(_selected.Id);
                if (ok)
                {
                    ShowInfo("Book deleted.");
                    ClearForm();
                    LoadGrid(txtSearch.Text.Trim());
                }
                else
                {
                    ShowWarning("Cannot delete: one or more copies are currently on loan.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Delete failed: " + ex.Message);
            }
        }

        // ── Add Copy ─────────────────────────────────────────────────────
        private void btnAddCopy_Click(object sender, EventArgs e)
        {
            if (_selected == null) { ShowWarning("Select a book title first."); return; }

            byte integrity = (byte)nudIntegrity.Value;
            try
            {
                _actualDal.Insert(_selected.Id, integrity);
                ShowInfo($"New copy added for \"{_selected.Name}\".");
                LoadGrid(txtSearch.Text.Trim());
                RefreshCopiesGrid(_selected.Id);
            }
            catch (Exception ex)
            {
                ShowError("Add copy failed: " + ex.Message);
            }
        }

        // ── Delete Copy ───────────────────────────────────────────────────
        private void btnDeleteCopy_Click(object sender, EventArgs e)
        {
            if (dgvCopies.CurrentRow == null) { ShowWarning("Select a copy to delete."); return; }

            int copyId = Convert.ToInt32(dgvCopies.CurrentRow.Cells["colCopyId"].Value);

            var confirm = MessageBox.Show(
                $"Delete physical copy #{copyId}?",
                "Confirm Delete Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = _actualDal.Delete(copyId);
                if (ok)
                {
                    ShowInfo("Copy deleted.");
                    LoadGrid(txtSearch.Text.Trim());
                    if (_selected != null) RefreshCopiesGrid(_selected.Id);
                }
                else
                    ShowWarning("Cannot delete: this copy is currently on loan.");
            }
            catch (Exception ex)
            {
                ShowError("Delete copy failed: " + ex.Message);
            }
        }

        // ── Cancel ───────────────────────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormState(editing: false);
            ClearForm();
        }

        // ── Close ────────────────────────────────────────────────────────
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── Image Handlers ───────────────────────────────────────────────
        private void btnImage_Click(object sender, EventArgs e)
        {
            ofdImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                _currentImagePath = ofdImage.FileName;
                try { pbImage.Image = Image.FromFile(_currentImagePath); }
                catch { ShowError("Invalid image file."); }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            _currentImagePath = null;
            pbImage.Image = null;
        }

        // ════════════════════════════════════════════════════════════════════
        //  GRID EVENTS
        // ════════════════════════════════════════════════════════════════════
        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvBooks.CurrentRow.Cells["colId"].Value);
            _selected = _books?.Find(b => b.Id == id);

            if (_selected != null)
            {
                RefreshCopiesGrid(_selected.Id);
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAddCopy.Enabled = true;
            }
        }

        private void RefreshCopiesGrid(int formalId)
        {
            var copies = _actualDal.GetByFormalId(formalId);
            dgvCopies.Rows.Clear();
            foreach (var c in copies)
            {
                string status = IsBorrowed(c.Id) ? "On Loan" : "Available";
                dgvCopies.Rows.Add(c.Id, c.FormalName, c.Integrity, c.DateCreate.ToString("yyyy-MM-dd"), status);
            }
        }

        private bool IsBorrowed(int bookActualId)
        {
            // Simple in-memory check: book appears in borrowed list
            var borrowed = _actualDal.GetBorrowedBooks();
            return borrowed.Exists(b => b.Id == bookActualId);
        }

        // ════════════════════════════════════════════════════════════════════
        //  UI HELPERS
        // ════════════════════════════════════════════════════════════════════
        private void CenterCard()
        {
            if (pnlCard != null)
            {
                pnlCard.Left = (this.ClientSize.Width - pnlCard.Width) / 2;
                pnlCard.Top = (this.ClientSize.Height - pnlCard.Height) / 2;
            }
        }

        private void SetFormState(bool editing)
        {
            // Show/hide edit panel
            pnlEditFields.Visible = editing;
            btnSave.Visible = editing;
            btnCancel.Visible = editing;

            // CRUD toolbar
            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing && _selected != null;
            btnDelete.Enabled = !editing && _selected != null;
            btnSearch.Enabled = !editing;
        }

        private void ClearForm()
        {
            txtName.Clear();
            dtpPublish.Checked = false;
            
            for (int i = 0; i < clbAuthors.Items.Count; i++) clbAuthors.SetItemChecked(i, false);
            for (int i = 0; i < clbGenres.Items.Count; i++) clbGenres.SetItemChecked(i, false);
            
            _currentImagePath = null;
            pbImage.Image = null;

            _selected = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAddCopy.Enabled = false;
            dgvCopies.Rows.Clear();
        }

        private void AttachHoverEffects()
        {
            this.Load += (_, __) =>
            {
                AttachHover(btnAdd, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
                AttachHover(btnEdit, Color.FromArgb(5, 150, 105), Color.FromArgb(16, 185, 129));
                AttachHover(btnDelete, Color.FromArgb(185, 28, 28), Color.FromArgb(220, 38, 38));
                AttachHover(btnSave, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
                AttachHover(btnAddCopy, Color.FromArgb(5, 150, 105), Color.FromArgb(16, 185, 129));
                AttachHover(btnDeleteCopy, Color.FromArgb(185, 28, 28), Color.FromArgb(220, 38, 38));

                btnCancel.MouseEnter += (s, e) => btnCancel.ForeColor = Color.FromArgb(29, 78, 216);
                btnCancel.MouseLeave += (s, e) => btnCancel.ForeColor = Color.FromArgb(120, 130, 145);
            };
        }

        private static void AttachHover(Button btn, Color hover, Color normal)
        {
            btn.MouseEnter += (_, __) => btn.BackColor = hover;
            btn.MouseLeave += (_, __) => btn.BackColor = normal;
        }

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
        }

        private static void ShowInfo(string msg) => MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static void ShowWarning(string msg) => MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private static void ShowError(string msg) => MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}