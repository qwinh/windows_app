using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Helpers;

namespace LibraryManagement
{
    public partial class LoginRegisterForm : Form
    {
        private readonly AuthService _authService;

        public LoginRegisterForm()
        {
            InitializeComponent();
            _authService = new AuthService();

            // UX – center cards when the right panel resizes (e.g. form loads)
            pnlRight.Resize += (_, __) => CenterCards();

            ShowLoginPanel();
        }

        // ─── UX: Card centering ────────────────────────────────────────────────────

        private void CenterCards() // UX
        {
            int rightW = pnlRight.ClientSize.Width;
            int rightH = pnlRight.ClientSize.Height;

            // Login card
            pnlLogin.Left = (rightW - pnlLogin.Width) / 2;
            pnlLogin.Top = (rightH - pnlLogin.Height) / 2;

            // Register card
            pnlRegister.Left = (rightW - pnlRegister.Width) / 2;
            pnlRegister.Top = Math.Max(10, (rightH - pnlRegister.Height) / 2);
        }

        // ─── Panel Switching ───────────────────────────────────────────────────────

        private void ShowLoginPanel()
        {
            pnlLogin.Visible = true;
            pnlRegister.Visible = false;

            // UX – Enter key triggers login
            this.AcceptButton = btnLogin;

            CenterCards();
            ActiveControl = txtLoginEmail;
        }

        private void ShowRegisterPanel()
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;

            // UX – Enter key triggers register
            this.AcceptButton = btnRegister;

            CenterCards();
            ActiveControl = txtRegName;
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            ClearLoginErrors();
            ShowRegisterPanel();
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            ClearRegisterErrors();
            ShowLoginPanel();
        }

        // ─── UX: Error clearers ────────────────────────────────────────────────────

        private void ClearLoginErrors() // UX
        {
            SetError(lblLoginError, "");
            SetError(lblLoginEmailError, "");
        }

        private void ClearRegisterErrors() // UX
        {
            SetError(lblRegisterError, "");
            SetError(lblRegEmailError, "");
            SetError(lblRegPasswordConfirmError, "");
        }

        // UX – helper: show/hide a label depending on whether message is empty
        private static void SetError(Label lbl, string message) // UX
        {
            lbl.Text = message;
            lbl.Visible = !string.IsNullOrEmpty(message);
        }

        // ─── UX: Button hover effects ──────────────────────────────────────────────

        protected override void OnLoad(EventArgs e) // UX
        {
            base.OnLoad(e);
            AttachHoverEffect(btnLogin, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
            AttachHoverEffect(btnRegister, Color.FromArgb(29, 78, 216), Color.FromArgb(37, 99, 235));
        }

        private static void AttachHoverEffect(Button btn, Color hoverColor, Color normalColor) // UX
        {
            btn.MouseEnter += (_, __) => btn.BackColor = hoverColor;
            btn.MouseLeave += (_, __) => btn.BackColor = normalColor;
        }

        // ─── UX: Real-time – Login panel ───────────────────────────────────────────

        private void txtLoginEmail_Leave(object sender, EventArgs e) => ValidateLoginEmail(); // UX

        private void txtLoginEmail_TextChanged(object sender, EventArgs e) // UX
        {
            if (lblLoginEmailError.Visible) SetError(lblLoginEmailError, "");
            if (lblLoginError.Visible) SetError(lblLoginError, "");
        }

        private void txtLoginPassword_TextChanged(object sender, EventArgs e) // UX
        {
            if (lblLoginError.Visible) SetError(lblLoginError, "");
        }

        private bool ValidateLoginEmail() // UX
        {
            string email = txtLoginEmail.Text.Trim();
            if (email.Length > 0 && !IsValidEmail(email))
            {
                SetError(lblLoginEmailError, "Invalid email format.");
                return false;
            }
            SetError(lblLoginEmailError, "");
            return true;
        }

        // ─── UX: Real-time – Register panel ────────────────────────────────────────

        private void txtRegName_TextChanged(object sender, EventArgs e) // UX
        {
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private void txtRegEmail_Leave(object sender, EventArgs e) => ValidateRegEmail(); // UX

        private void txtRegEmail_TextChanged(object sender, EventArgs e) // UX
        {
            if (lblRegEmailError.Visible) SetError(lblRegEmailError, "");
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private bool ValidateRegEmail() // UX
        {
            string email = txtRegEmail.Text.Trim();
            if (email.Length > 0 && !IsValidEmail(email))
            {
                SetError(lblRegEmailError, "Invalid email format.");
                return false;
            }
            SetError(lblRegEmailError, "");
            return true;
        }

        private void txtRegPassword_TextChanged(object sender, EventArgs e) // UX
        {
            UpdatePasswordStrength(txtRegPassword.Text);
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private void UpdatePasswordStrength(string password) // UX
        {
            if (password.Length == 0) { lblRegPasswordStrength.Text = ""; return; }

            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasSpecial = Regex.IsMatch(password, @"[^A-Za-z0-9]");

            bool isStrong = password.Length >= 12
                         || (password.Length >= 8 && hasUpper && hasLower && hasDigit && hasSpecial);

            if (password.Length < 8)
            {
                lblRegPasswordStrength.Text = "● Weak";
                lblRegPasswordStrength.ForeColor = Color.FromArgb(210, 50, 50);
            }
            else if (isStrong)
            {
                lblRegPasswordStrength.Text = "● Strong";
                lblRegPasswordStrength.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblRegPasswordStrength.Text = "● Medium";
                lblRegPasswordStrength.ForeColor = Color.FromArgb(234, 88, 12);
            }
        }

        private void txtRegPasswordConfirm_Leave(object sender, EventArgs e) => ValidatePasswordConfirm(); // UX

        private void txtRegPasswordConfirm_TextChanged(object sender, EventArgs e) // UX
        {
            if (lblRegPasswordConfirmError.Visible) SetError(lblRegPasswordConfirmError, "");
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private bool ValidatePasswordConfirm() // UX
        {
            if (txtRegPasswordConfirm.Text != txtRegPassword.Text)
            {
                SetError(lblRegPasswordConfirmError, "Passwords do not match.");
                return false;
            }
            SetError(lblRegPasswordConfirmError, "");
            return true;
        }

        // ─── UX: Show/hide password toggles ────────────────────────────────────────

        private void btnShowLoginPassword_Click(object sender, EventArgs e) // UX
        {
            bool isHidden = txtLoginPassword.PasswordChar == '●';
            txtLoginPassword.PasswordChar = isHidden ? '\0' : '●';
            btnShowLoginPassword.IconChar = isHidden ? FontAwesome.Sharp.IconChar.EyeSlash : FontAwesome.Sharp.IconChar.Eye;
        }

        private void btnShowRegPassword_Click(object sender, EventArgs e) // UX
        {
            bool isHidden = txtRegPassword.PasswordChar == '●';
            txtRegPassword.PasswordChar = isHidden ? '\0' : '●';
            btnShowRegPassword.IconChar = isHidden ? FontAwesome.Sharp.IconChar.EyeSlash : FontAwesome.Sharp.IconChar.Eye;
        }

        private void btnShowRegPasswordConfirm_Click(object sender, EventArgs e) // UX
        {
            bool isHidden = txtRegPasswordConfirm.PasswordChar == '●';
            txtRegPasswordConfirm.PasswordChar = isHidden ? '\0' : '●';
            btnShowRegPasswordConfirm.IconChar = isHidden ? FontAwesome.Sharp.IconChar.EyeSlash : FontAwesome.Sharp.IconChar.Eye;
        }

        // ─── UX: Email format helper ───────────────────────────────────────────────

        private static bool IsValidEmail(string email) // UX
            => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        // ─── UX: Loading state helper ──────────────────────────────────────────────

        private void SetLoadingState(Button btn, bool isLoading, string defaultText, string loadingText)
        {
            btn.Enabled = !isLoading;
            btn.Text = isLoading ? loadingText : defaultText;
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        // ─── Login submit (async + loading state) ─────────────────────────────────

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateLoginEmail()) return;
            ClearLoginErrors();

            SetLoadingState(btnLogin, true, "Sign In", "Signing in…");
            try
            {
                var result = await Task.Run(() =>
                    _authService.Login(txtLoginEmail.Text, txtLoginPassword.Text));

                if (result.Success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    SetError(lblLoginError, result.ErrorMessage);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(btnLogin, false, "Sign In", "Signing in…");
            }
        }

        // ─── Register submit (async + loading state) ──────────────────────────────

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            bool emailOk = ValidateRegEmail();
            bool confirmOk = ValidatePasswordConfirm();
            if (!emailOk || !confirmOk) return;

            ClearRegisterErrors();

            SetLoadingState(btnRegister, true, "Create Account", "Creating account…");
            try
            {
                string registeredEmail = txtRegEmail.Text;
                string name = txtRegName.Text;
                string pass = txtRegPassword.Text;

                var result = await Task.Run(() =>
                    _authService.Register(name, registeredEmail, pass));

                if (result.Success)
                {
                    // Clear fields
                    txtRegName.Text = "";
                    txtRegEmail.Text = "";
                    txtRegPassword.Text = "";
                    txtRegPasswordConfirm.Text = "";    // UX
                    lblRegPasswordStrength.Text = "";   // UX

                    // UX – pre-fill email on login panel (kept working)
                    txtLoginEmail.Text = registeredEmail;
                    ShowLoginPanel();

                    MessageBox.Show("Registration successful! You may now sign in.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    SetError(lblRegisterError, result.ErrorMessage);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(btnRegister, false, "Create Account", "Creating account…");
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // UI Polish - Custom TextBox Border Focus Handlers
        // ══════════════════════════════════════════════════════════════════════

        private readonly System.Drawing.Color _borderColorNormal = System.Drawing.Color.FromArgb(210, 218, 230);
        private readonly System.Drawing.Color _borderColorFocus = System.Drawing.Color.FromArgb(37, 99, 235);







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

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

