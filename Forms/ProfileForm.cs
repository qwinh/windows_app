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
        private bool _isEditMode = false;

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
        // UI Polish - Custom TextBox Border Focus Handlers
        // ══════════════════════════════════════════════════════════════════════

        private readonly System.Drawing.Color _borderColorNormal = System.Drawing.Color.FromArgb(210, 218, 230);
        private readonly System.Drawing.Color _borderColorFocus = System.Drawing.Color.FromArgb(37, 99, 235);

        private void txtFirstName_EnterFocus(object sender, EventArgs e) {}
        private void txtFirstName_LeaveFocus(object sender, EventArgs e) {}

        private void txtPhone_EnterFocus(object sender, EventArgs e) {}
        private void txtPhone_LeaveFocus(object sender, EventArgs e) {}

        private void txtAddress_EnterFocus(object sender, EventArgs e) {}
        private void txtAddress_LeaveFocus(object sender, EventArgs e) {}

        private void txtEmail_EnterFocus(object sender, EventArgs e) { /* Read-only, do not change border color on focus typically, but leaving handler active */ }
        private void txtEmail_LeaveFocus(object sender, EventArgs e) { }

        // ══════════════════════════════════════════════════════════════════════
        // UI Polish - Card Panel Borders
        // ══════════════════════════════════════════════════════════════════════
        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;
            
            // Soft border color #E2E8F0
            using (Pen borderPen = new Pen(System.Drawing.Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, pnl.Width - 1, pnl.Height - 1);
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
