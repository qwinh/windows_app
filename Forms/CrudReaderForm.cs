using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.DAL;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class CrudReaderForm : Form
    {
        // ── Fields ───────────────────────────────────────────────────────────
        private readonly ReaderDAL _readerDal = new ReaderDAL();
        private List<Reader> _readers;
        private Reader _selected;
        private bool _isEditMode;

        // ── Constructor ──────────────────────────────────────────────────────
        public CrudReaderForm()
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
                _readers = string.IsNullOrWhiteSpace(keyword)
                    ? _readerDal.GetAll()
                    : _readerDal.Search(keyword);

                dgvReaders.Rows.Clear();
                foreach (var r in _readers)
                {
                    bool expired = r.DateExpire.HasValue && r.DateExpire.Value < DateTime.Today;
                    dgvReaders.Rows.Add(
                        r.Id,
                        r.Name,
                        r.Email ?? "—",
                        r.Phone ?? "—",
                        r.Address ?? "—",
                        r.DateExpire.HasValue ? r.DateExpire.Value.ToString("yyyy-MM-dd") : "—",
                        r.Integrity,
                        expired ? "Expired" : "Active"
                    );

                    // Tint expired rows
                    if (expired)
                    {
                        var row = dgvReaders.Rows[dgvReaders.Rows.Count - 1];
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                    }
                }

                lblCount.Text = $"{_readers.Count} record(s)";
            }
            catch (Exception ex)
            {
                ShowError("Error loading readers: " + ex.Message);
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

        // ── Add ───────────────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _selected = null;
            _isEditMode = false;
            ClearForm();
            // Default expire = 1 year from today
            dtpExpire.Checked = true;
            dtpExpire.Value = DateTime.Today.AddYears(1);
            nudIntegrity.Value = 5;
            SetFormState(editing: true);
            txtName.Focus();
        }

        // ── Edit ──────────────────────────────────────────────────────────
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selected == null) { ShowWarning("Please select a reader to edit."); return; }

            _isEditMode = true;
            txtName.Text = _selected.Name;
            txtEmail.Text = _selected.Email ?? string.Empty;
            txtPhone.Text = _selected.Phone ?? string.Empty;
            txtAddress.Text = _selected.Address ?? string.Empty;

            dtpExpire.Checked = _selected.DateExpire.HasValue;
            if (_selected.DateExpire.HasValue) dtpExpire.Value = _selected.DateExpire.Value;

            nudIntegrity.Value = _selected.Integrity;

            SetFormState(editing: true);
            txtName.Focus();
        }

        // ── Save ──────────────────────────────────────────────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                ShowWarning("Reader name cannot be empty.");
                txtName.Focus();
                return;
            }

            // Basic e-mail format check
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !email.Contains("@"))
            {
                ShowWarning("Please enter a valid e-mail address.");
                txtEmail.Focus();
                return;
            }

            try
            {
                var reader = new Reader
                {
                    Name = name,
                    Email = string.IsNullOrEmpty(email) ? null : email,
                    Phone = string.IsNullOrEmpty(txtPhone.Text.Trim()) ? null : txtPhone.Text.Trim(),
                    Address = string.IsNullOrEmpty(txtAddress.Text.Trim()) ? null : txtAddress.Text.Trim(),
                    DateExpire = dtpExpire.Checked ? dtpExpire.Value.Date : (DateTime?)null,
                    Integrity = (byte)nudIntegrity.Value
                };

                if (_isEditMode)
                {
                    reader.Id = _selected.Id;
                    _readerDal.Update(reader);
                    ShowInfo("Reader updated successfully.");
                }
                else
                {
                    _readerDal.Insert(reader);
                    ShowInfo("Reader added successfully.");
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
            if (_selected == null) { ShowWarning("Please select a reader to delete."); return; }

            var confirm = MessageBox.Show(
                $"Delete reader \"{_selected.Name}\"?\nThis cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = _readerDal.Delete(_selected.Id);
                if (ok)
                {
                    ShowInfo("Reader deleted.");
                    ClearForm();
                    LoadGrid(txtSearch.Text.Trim());
                }
                else
                {
                    ShowWarning("Cannot delete: this reader still has unreturned books on loan.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Delete failed: " + ex.Message);
            }
        }

        // ── Renew Membership ──────────────────────────────────────────────
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (_selected == null) { ShowWarning("Please select a reader to renew."); return; }

            DateTime newExpire = DateTime.Today.AddYears(1);
            if (_selected.DateExpire.HasValue && _selected.DateExpire.Value > DateTime.Today)
                newExpire = _selected.DateExpire.Value.AddYears(1);   // Extend from current expiry

            var confirm = MessageBox.Show(
                $"Renew \"{_selected.Name}\"'s membership until {newExpire:yyyy-MM-dd}?",
                "Renew Membership", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _readerDal.RenewMembership(_selected.Id, newExpire);
                ShowInfo($"Membership renewed until {newExpire:yyyy-MM-dd}.");
                LoadGrid(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                ShowError("Renew failed: " + ex.Message);
            }
        }

        // ── Cancel ────────────────────────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetFormState(editing: false);
            ClearForm();
        }

        // ── Close ─────────────────────────────────────────────────────────
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ════════════════════════════════════════════════════════════════════
        //  GRID EVENTS
        // ════════════════════════════════════════════════════════════════════
        private void dgvReaders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReaders.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvReaders.CurrentRow.Cells["colId"].Value);
            _selected = _readers?.Find(r => r.Id == id);

            if (_selected != null)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnRenew.Enabled = true;
            }
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
            pnlEditFields.Visible = editing;
            btnSave.Visible = editing;
            btnCancel.Visible = editing;

            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing && _selected != null;
            btnDelete.Enabled = !editing && _selected != null;
            btnRenew.Enabled = !editing && _selected != null;
            btnSearch.Enabled = !editing;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpExpire.Checked = false;
            nudIntegrity.Value = 5;

            _selected = null;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnRenew.Enabled = false;
        }

        private void AttachHoverEffects()
        {
            this.Load += (_, __) =>
            {
                AttachHover(btnAdd, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
                AttachHover(btnEdit, Color.FromArgb(5, 150, 105), Color.FromArgb(16, 185, 129));
                AttachHover(btnDelete, Color.FromArgb(185, 28, 28), Color.FromArgb(220, 38, 38));
                AttachHover(btnRenew, Color.FromArgb(180, 83, 9), Color.FromArgb(217, 119, 6));
                AttachHover(btnSave, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));

                btnCancel.MouseEnter += (s, ev) => btnCancel.ForeColor = Color.FromArgb(29, 78, 216);
                btnCancel.MouseLeave += (s, ev) => btnCancel.ForeColor = Color.FromArgb(120, 130, 145);
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