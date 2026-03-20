using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LibraryManagement.BLL;
using LibraryManagement.Helpers;

namespace LibraryManagement
{
    public partial class ProfileForm : Form
    {
        private readonly AuthService _authService;
        
        // Store values as they were originally loaded from DB
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
            
            pnlRight.Resize += (_, __) => CenterProfileCard();

            pnlAvatar.Click += Avatar_Click;
            // Provide a tooltip hint in edit mode
            pnlAvatar.Cursor = Cursors.Default;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AttachHoverEffect(btnEdit, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
            AttachHoverEffect(btnSave, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
            AttachHoverEffect(btnCancel, Color.FromArgb(220, 225, 235), Color.FromArgb(240, 242, 245));

            LoadUserProfile();
            SetViewMode();
        }

        private void CenterProfileCard()
        {
            int rightW = pnlRight.ClientSize.Width;
            int rightH = pnlRight.ClientSize.Height;

            pnlProfileCard.Left = (rightW - pnlProfileCard.Width) / 2;
            pnlProfileCard.Top = Math.Max(pnlHeader.Height + 20, (rightH + pnlHeader.Height - pnlProfileCard.Height) / 2);
        }

        private static void AttachHoverEffect(Button btn, Color hoverColor, Color normalColor)
        {
            btn.MouseEnter += (_, __) => btn.BackColor = hoverColor;
            btn.MouseLeave += (_, __) => btn.BackColor = normalColor;
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

            // Initials
            string initials = "";
            var parts = _originalName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                initials += parts[0][0];
                if (parts.Length > 1)
                {
                    initials += parts[parts.Length - 1][0];
                }
            }
            lblAvatar.Text = initials.ToUpper();
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
                    // REVIEW [LOW]: Avatar load errors are swallowed silently. Consider logging if a logging framework is added.
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
            txtEmail.ReadOnly = true; // Always read-only

            txtFirstName.BackColor = Color.White;
            txtPhone.BackColor = Color.White;
            txtAddress.BackColor = Color.White;
            txtEmail.BackColor = Color.FromArgb(245, 247, 250); // Muted to show read-only

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            _isEditMode = false;
            pnlAvatar.Cursor = Cursors.Default;

            ClearErrors();
            SetFeedback("");
        }

        private void SetEditMode()
        {
            txtFirstName.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtEmail.ReadOnly = true; // Always read-only

            txtFirstName.BackColor = SystemColors.Window;
            txtPhone.BackColor = SystemColors.Window;
            txtAddress.BackColor = SystemColors.Window;
            txtEmail.BackColor = Color.FromArgb(245, 247, 250);

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

        // --- Real-time Validation & UX ---

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
            bool isValid = true;

            // Full Name validation (required)
            if (txtFirstName.Text.Trim() != _originalName)
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    SetError(lblErrFirstName, "Full Name is required.");
                    isValid = false;
                }
            }

            // Phone validation
            if (txtPhone.Text.Trim() != _originalPhone)
            {
                string p = txtPhone.Text.Trim();
                if (p.Length > 0 && !Regex.IsMatch(p, @"^[\d\+\-\s]+$"))
                {
                    SetError(lblErrPhone, "Phone can only contain digits, spaces, +, and -");
                    isValid = false;
                }
            }

            // Address
            // (Only checking if changed, no strict rules for format yet, assume up to 500 chars limit handled implicitly or here)
            if (txtAddress.Text.Trim() != _originalAddress)
            {
                if (txtAddress.Text.Trim().Length > 500)
                {
                    SetError(lblErrAddress, "Address is too long (max 500 chars).");
                    isValid = false;
                }
            }

            return isValid;
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

            // Partial Edit Rule: did anything change?
            if (newName == _originalName && newPhone == _originalPhone && newAddress == _originalAddress && _currentImagePath == _originalImagePath)
            {
                SetViewMode();
                SetFeedback("No changes were made.");
                return;
            }

            ClearErrors();
            SetLoadingState(true);

            // REVIEW [MEDIUM]: SessionManager.CurrentEmployee could theoretically be null if session expires mid-edit. Guard if this becomes a concern.
            int empId = SessionManager.CurrentEmployee.Id;
            string finalImagePath = _currentImagePath;

            // Handle image copy if a new image was selected
            if (_currentImagePath != _originalImagePath && !string.IsNullOrEmpty(_currentImagePath))
            {
                try
                {
                    string imagesDir = Path.Combine(Application.StartupPath, "Images", "Employees");
                    if (!Directory.Exists(imagesDir))
                    {
                        Directory.CreateDirectory(imagesDir);
                    }
                    string ext = Path.GetExtension(_currentImagePath);
                    string fileName = $"emp_{empId}_{DateTime.Now.Ticks}{ext}";
                    finalImagePath = Path.Combine(imagesDir, fileName);
                    File.Copy(_currentImagePath, finalImagePath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetLoadingState(false);
                    return;
                }
            }

            try
            {
                var result = await Task.Run(() => _authService.UpdateProfile(empId, newName, newPhone, newAddress, finalImagePath));

                if (result.Success)
                {
                    // Update successfully. The BLL also updated SessionManager inline.
                    LoadUserProfile(); // refresh the UI (like Avatar and stored original values)
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

        // ══════════════════════════════════════════════════════════════════════
        // FEATURE — Change Password
        // ══════════════════════════════════════════════════════════════════════

        private void chkShowCurrentPassword_CheckedChanged(object sender, EventArgs e) // UX
        {
            txtCurrentPassword.UseSystemPasswordChar = !chkShowCurrentPassword.Checked;
        }

        private void chkShowNewPassword_CheckedChanged(object sender, EventArgs e) // UX
        {
            bool show = chkShowNewPassword.Checked;
            txtNewPassword.UseSystemPasswordChar = !show;
            txtConfirmNewPassword.UseSystemPasswordChar = !show;
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e) // UX
        {
            // Clear mismatch error on each keystroke
            if (lblNewPasswordError.Visible) SetError(lblNewPasswordError, "");

            string pwd = txtNewPassword.Text;
            if (pwd.Length == 0)
            {
                lblPasswordStrength.Text = "";
                lblPasswordStrength.Visible = false;
                return;
            }

            bool hasUpper   = Regex.IsMatch(pwd, @"[A-Z]");
            bool hasLower   = Regex.IsMatch(pwd, @"[a-z]");
            bool hasDigit   = Regex.IsMatch(pwd, @"\d");
            bool hasSpecial = Regex.IsMatch(pwd, @"[^A-Za-z0-9]");
            bool isStrong   = pwd.Length >= 12 || (pwd.Length >= 8 && hasUpper && hasLower && hasDigit && hasSpecial);

            if (pwd.Length < 8)
            {
                lblPasswordStrength.Text = "● Weak";
                lblPasswordStrength.ForeColor = Color.FromArgb(210, 50, 50);
            }
            else if (isStrong)
            {
                lblPasswordStrength.Text = "● Strong";
                lblPasswordStrength.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblPasswordStrength.Text = "● Medium";
                lblPasswordStrength.ForeColor = Color.FromArgb(234, 88, 12);
            }
            lblPasswordStrength.Visible = true;
        }

        private void txtConfirmNewPassword_Leave(object sender, EventArgs e) // UX
        {
            if (txtConfirmNewPassword.Text.Length > 0 && txtConfirmNewPassword.Text != txtNewPassword.Text)
            {
                SetError(lblNewPasswordError, "Passwords do not match.");
            }
        }

        private async void btnChangePassword_Click(object sender, EventArgs e) // FEATURE
        {
            // 1. Validate current password not empty
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                SetError(lblCurrentPasswordError, "Current password is required.");
                return;
            }
            SetError(lblCurrentPasswordError, "");

            // 2. Validate new password strength (not Weak)
            string newPwd = txtNewPassword.Text;
            if (newPwd.Length < 8)
            {
                SetError(lblNewPasswordError, "Password must be at least 8 characters.");
                return;
            }

            // 3. Validate confirm match
            if (newPwd != txtConfirmNewPassword.Text)
            {
                SetError(lblNewPasswordError, "Passwords do not match.");
                return;
            }
            SetError(lblNewPasswordError, "");

            // 4. Loading state
            btnChangePassword.Enabled = false;
            btnChangePassword.Text = "Saving\u2026";
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

                // 5. Success — clear all fields
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
                // 6. Restore loading state
                if (!IsDisposed)
                {
                    btnChangePassword.Enabled = true;
                    btnChangePassword.Text = "Update Password";
                    Cursor = Cursors.Default;
                }
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // UI Polish - Card Panel Borders
        // ══════════════════════════════════════════════════════════════════════
        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                using (Pen borderPen = new Pen(System.Drawing.Color.FromArgb(226, 232, 240), 1))
                {
                    e.Graphics.DrawRectangle(borderPen, 0, 0, pnl.Width - 1, pnl.Height - 1);
                }
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // UI Polish - Avatar Circle
        // ══════════════════════════════════════════════════════════════════════
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
                using (var font = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold))
                {
                    var textSize = g.MeasureString(lblAvatar.Text, font);
                    var textPoint = new System.Drawing.PointF(
                        (pnlAvatar.Width - textSize.Width) / 2f,
                        (pnlAvatar.Height - textSize.Height) / 2f);
                    g.DrawString(lblAvatar.Text, font, System.Drawing.Brushes.White, textPoint);
                }
            }
        }
    }
}
