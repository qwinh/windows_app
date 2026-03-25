using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Helpers;

namespace LibraryManagement
{
    public partial class ProfileForm : Form
    {
        private readonly AuthService _authService;
        
        private string _originalName;
        private string _originalPhone;
        private string _originalAddress;
        private string _originalImagePath;

        private string _currentImagePath;
        private Image _avatarImage;
        private bool _isEditMode;

        public ProfileForm()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadUserProfile();
            SetViewMode();
        }

        private void LoadUserProfile()
        {
            if (!SessionManager.IsLoggedIn) return;

            var user = SessionManager.CurrentEmployee;

            _originalName = user.Name ?? "";
            _originalPhone = user.Phone ?? "";
            _originalAddress = user.Address ?? "";
            _originalImagePath = user.ImagePath;

            _currentImagePath = _originalImagePath;
            LoadAvatarImage(_currentImagePath);

            txtFirstName.Text = _originalName; // we will use txtFirstName as "Full Name" based on validation
            txtPhone.Text = _originalPhone;
            txtAddress.Text = _originalAddress;
            txtEmail.Text = user.Email ?? "";
            
            lblDisplayName.Text = _originalName;
            lblDisplayRole.Text = "Librarian";


        }

        private void LoadAvatarImage(string path)
        {
            if (_avatarImage != null)
            {
                _avatarImage.Dispose();
                _avatarImage = null;
            }

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    // Use FromStream to avoid locking the file
                    using (var ms = new MemoryStream(File.ReadAllBytes(path)))
                    {
                        _avatarImage = Image.FromStream(ms);
                    }
                }
                catch
                {
                    _avatarImage = null;
                }
            }
            pnlAvatar.Invalidate(); // Trigger repainting of the avatar
        }

        // --- Modes ---

        private void SetViewMode()
        {
            txtFirstName.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAddress.ReadOnly = true;

            txtFirstName.BackColor = Color.White;
            txtPhone.BackColor = Color.White;
            txtAddress.BackColor = Color.White;

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            _isEditMode = false;

            ClearErrors();
            SetFeedback("");
        }

        private void SetEditMode()
        {
            txtFirstName.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAddress.ReadOnly = false;

            txtFirstName.BackColor = SystemColors.Window;
            txtPhone.BackColor = SystemColors.Window;
            txtAddress.BackColor = SystemColors.Window;

            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            _isEditMode = true;
            pnlAvatar.Cursor = Cursors.Hand;

            ActiveControl = txtFirstName;
        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            if (!_isEditMode) return;
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Profile Photo";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImagePath = ofd.FileName;
                    LoadAvatarImage(_currentImagePath);
                }
            }
        }

        private static string GetInitials(string fullName)
        {
            var parts = (fullName ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "";
            string initials = "" + parts[0][0];
            if (parts.Length > 1) initials += parts[parts.Length - 1][0];
            return initials.ToUpper();
        }

        private void ClearErrors()
        {
            SetError(lblErrFirstName, "");
            SetError(lblErrPhone, "");
            SetError(lblErrAddress, "");
        }

        private static void SetError(Label lbl, string message)
        {
            lbl.Text = message;
            lbl.Visible = !string.IsNullOrEmpty(message);
        }

        private void SetFeedback(string message, bool isError = false)
        {
            lblFeedback.Text = message;
            lblFeedback.ForeColor = isError ? Color.FromArgb(180, 30, 30) : Color.FromArgb(22, 163, 74);
            lblFeedback.BackColor = isError ? Color.FromArgb(255, 235, 235) : Color.FromArgb(220, 252, 231);
            lblFeedback.Visible = !string.IsNullOrEmpty(message);
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (lblErrFirstName.Visible) SetError(lblErrFirstName, "");
            if (lblFeedback.Visible) SetFeedback("");
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (lblErrPhone.Visible) SetError(lblErrPhone, "");
            if (lblFeedback.Visible) SetFeedback("");
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (lblErrAddress.Visible) SetError(lblErrAddress, "");
            if (lblFeedback.Visible) SetFeedback("");
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                SetError(lblErrFirstName, "Full Name is required.");
                return false;
            }
            return true;
        }

        // --- Button Handlers ---

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Revert values
            txtFirstName.Text = _originalName;
            txtPhone.Text = _originalPhone;
            txtAddress.Text = _originalAddress;
            _currentImagePath = _originalImagePath;
            LoadAvatarImage(_currentImagePath);
            SetViewMode();
        }

        private void SetLoadingState(bool isLoading)
        {
            btnSave.Enabled = !isLoading;
            btnSave.Text = isLoading ? "Saving..." : "Save Changes";
            btnCancel.Enabled = !isLoading;
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            string newName = txtFirstName.Text.Trim();
            string newPhone = txtPhone.Text.Trim();
            string newAddress = txtAddress.Text.Trim();

            if (newName == _originalName && newPhone == _originalPhone && newAddress == _originalAddress && _currentImagePath == _originalImagePath)
            {
                SetViewMode();
                SetFeedback("No changes were made.");
                return;
            }

            ClearErrors();
            SetLoadingState(true);

            int empId = SessionManager.CurrentEmployee.Id;
            string imagesDir = Path.Combine(Application.StartupPath, "Images", "Employees");

            try
            {
                var result = await Task.Run(() =>
                    _authService.UpdateProfile(empId, newName, newPhone, newAddress, _currentImagePath, _originalImagePath, imagesDir));

                if (result.Success)
                {
                    LoadUserProfile();
                    SetViewMode();
                    SetFeedback("Profile updated successfully.");
                }
                else
                {
                    SetFeedback(result.ErrorMessage, isError: true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // FEATURE — Change Password

        private void chkShowCurrentPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtCurrentPassword.UseSystemPasswordChar = !chkShowCurrentPassword.Checked;
        }

        private void chkShowNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShowNewPassword.Checked;
            txtNewPassword.UseSystemPasswordChar = !show;
            txtConfirmNewPassword.UseSystemPasswordChar = !show;
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            // Clear mismatch error on each keystroke
            if (lblNewPasswordError.Visible) SetError(lblNewPasswordError, "");

            string pwd = txtNewPassword.Text;
            var strength = AuthService.CalculatePasswordStrength(pwd);

            switch (strength)
            {
                case PasswordStrength.None:
                    lblPasswordStrength.Text = "";
                    lblPasswordStrength.Visible = false;
                    return;
                case PasswordStrength.Weak:
                    lblPasswordStrength.Text = "● Weak";
                    lblPasswordStrength.ForeColor = Color.FromArgb(210, 50, 50);
                    break;
                case PasswordStrength.Medium:
                    lblPasswordStrength.Text = "● Medium";
                    lblPasswordStrength.ForeColor = Color.FromArgb(234, 88, 12);
                    break;
                case PasswordStrength.Strong:
                    lblPasswordStrength.Text = "● Strong";
                    lblPasswordStrength.ForeColor = Color.FromArgb(22, 163, 74);
                    break;
            }
            lblPasswordStrength.Visible = true;
        }

        private void txtConfirmNewPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmNewPassword.Text.Length > 0 && txtConfirmNewPassword.Text != txtNewPassword.Text)
            {
                SetError(lblNewPasswordError, "Passwords do not match.");
            }
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Validate current password not empty
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                SetError(lblCurrentPasswordError, "Current password is required.");
                return;
            }
            SetError(lblCurrentPasswordError, "");

            // Validate new password strength (not Weak)
            string newPwd = txtNewPassword.Text;
            if (newPwd.Length < 8)
            {
                SetError(lblNewPasswordError, "Password must be at least 8 characters.");
                return;
            }

            // Validate confirm match
            if (newPwd != txtConfirmNewPassword.Text)
            {
                SetError(lblNewPasswordError, "Passwords do not match.");
                return;
            }
            SetError(lblNewPasswordError, "");

            // Loading state
            btnChangePassword.Enabled = false;
            btnChangePassword.Text = "Saving";
            Cursor = Cursors.WaitCursor;

            try
            {
                var employee = SessionManager.CurrentEmployee;
                string current = txtCurrentPassword.Text;

                var result = await Task.Run(() => _authService.ChangePassword(employee, current, newPwd));

                if (!result.Success)
                {
                    // Wrong current password or DB error — show inline under the relevant field
                    SetError(lblCurrentPasswordError, result.ErrorMessage);
                    return;
                }

                // Success — clear all fields
                txtCurrentPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmNewPassword.Text = "";
                chkShowCurrentPassword.Checked = false;
                chkShowNewPassword.Checked = false;
                lblPasswordStrength.Text = "";
                lblPasswordStrength.Visible = false;

                lblChangePasswordSuccess.Text = "Password changed successfully.";
                lblChangePasswordSuccess.Visible = true;

                // Auto-hide after 3 seconds
                await Task.Delay(3000);
                if (!IsDisposed) lblChangePasswordSuccess.Visible = false;
            }
            catch (Exception ex)
            {
                // Unexpected error (network, etc.)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restore loading state
                if (!IsDisposed)
                {
                    btnChangePassword.Enabled = true;
                    btnChangePassword.Text = "Update Password";
                    Cursor = Cursors.Default;
                }
            }
        }

        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var rect = new System.Drawing.Rectangle(0, 0, pnlAvatar.Width - 1, pnlAvatar.Height - 1);

            if (_avatarImage != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(rect);
                    g.SetClip(path);
                    g.DrawImage(_avatarImage, rect);
                }
            }
            else
            {
                // Fill circle with primary color
                using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(37, 99, 235)))
                {
                    g.FillEllipse(brush, rect);
                }

                // Draw initial letter, centered
                string initials = GetInitials(_originalName);
                using (var font = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold))
                {
                    var textSize = g.MeasureString(initials, font);
                    var textPoint = new System.Drawing.PointF(
                        (pnlAvatar.Width - textSize.Width) / 2f,
                        (pnlAvatar.Height - textSize.Height) / 2f);
                    g.DrawString(initials, font, System.Drawing.Brushes.White, textPoint);
                }
            }
        }
    }
}
