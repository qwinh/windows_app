using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.Forms
{
    public partial class ReaderDetailForm : Form
    {
        private readonly ReaderService _service;
        private readonly Reader _editing;

        private static readonly Color ClrBlue = Color.FromArgb(28, 98, 190);
        private static readonly Color ClrGreen = Color.FromArgb(0, 150, 70);

        public ReaderDetailForm(ReaderService service, Reader reader)
        {
            _service = service;
            _editing = reader;
            InitializeComponent();

            if (_editing != null)
            {
                // Edit mode — blue header, blue Update button
                lblTitle.Text = "Edit Reader";
                btnSave.Text = "Update";
                btnSave.BackColor = ClrBlue;
                Text = "Edit Reader";
                PopulateFields();
            }
            // Add mode — blue header already set, green Save button already set in Designer
        }

        private void PopulateFields()
        {
            txtName.Text = _editing.Name;
            txtEmail.Text = _editing.Email ?? "";
            txtPhone.Text = _editing.Phone ?? "";
            txtAddress.Text = _editing.Address ?? "";
            txtImagePath.Text = _editing.ImagePath ?? "";
            nudIntegrity.Value = _editing.Integrity;

            if (_editing.DateExpire.HasValue)
                dtpExpire.Value = _editing.DateExpire.Value;
            else
            {
                chkNoExpiry.Checked = true;
                dtpExpire.Enabled = false;
            }
        }

        private void chkNoExpiry_CheckedChanged(object sender, EventArgs e)
            => dtpExpire.Enabled = !chkNoExpiry.Checked;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Reader r = new Reader
            {
                Name = txtName.Text.Trim(),
                Email = Empty(txtEmail.Text),
                Phone = Empty(txtPhone.Text),
                Address = Empty(txtAddress.Text),
                ImagePath = Empty(txtImagePath.Text),
                DateExpire = chkNoExpiry.Checked ? (DateTime?)null : dtpExpire.Value.Date,
                Integrity = (byte)nudIntegrity.Value,
                DateCreate = _editing != null ? _editing.DateCreate : DateTime.Now
            };

            (bool ok, string error) result;
            if (_editing == null)
                result = _service.Add(r);
            else
            {
                r.Id = _editing.Id;
                result = _service.Update(r);
            }

            if (result.ok)
            {
                MessageBox.Show(
                    _editing == null ? "Reader added successfully." : "Reader updated successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show(result.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Title = "Select Image";
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtImagePath.Text = dlg.FileName;
            dlg.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = DialogResult.Cancel; Close(); }

        private static string Empty(string s)
            => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}