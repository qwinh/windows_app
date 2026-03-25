using System;
using System.Drawing;
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
            ShowLoginPanel();
        }

        // ─── Panel Switching ───
        private void ShowLoginPanel()
        {
            pnlLogin.Visible = true;
            pnlRegister.Visible = false;

            this.AcceptButton = btnLogin;

            ActiveControl = txtLoginEmail;
        }

        private void ShowRegisterPanel()
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;

            this.AcceptButton = btnRegister;

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

        private void ClearLoginErrors()
        {
            SetError(lblLoginError, "");
            SetError(lblLoginEmailError, "");
        }

        private void ClearRegisterErrors()
        {
            SetError(lblRegisterError, "");
            SetError(lblRegEmailError, "");
            SetError(lblRegPasswordConfirmError, "");
        }

        private static void SetError(Label lbl, string message)
        {
            lbl.Text = message;
            lbl.Visible = !string.IsNullOrEmpty(message);
        }

        private void txtLoginEmail_Leave(object sender, EventArgs e) => ValidateLoginEmail();

        private void txtLoginEmail_TextChanged(object sender, EventArgs e)
        {
            if (lblLoginEmailError.Visible) SetError(lblLoginEmailError, "");
            if (lblLoginError.Visible) SetError(lblLoginError, "");
        }

        private void txtLoginPassword_TextChanged(object sender, EventArgs e)
        {
            if (lblLoginError.Visible) SetError(lblLoginError, "");
        }

        private bool ValidateLoginEmail()
        {
            string email = txtLoginEmail.Text.Trim();
            if (email.Length > 0 && !AuthService.IsValidEmail(email))
            {
                SetError(lblLoginEmailError, "Invalid email format.");
                return false;
            }
            SetError(lblLoginEmailError, "");
            return true;
        }

        private void txtRegName_TextChanged(object sender, EventArgs e)
        {
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private void txtRegEmail_Leave(object sender, EventArgs e) => ValidateRegEmail();

        private void txtRegEmail_TextChanged(object sender, EventArgs e)
        {
            if (lblRegEmailError.Visible) SetError(lblRegEmailError, "");
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private bool ValidateRegEmail()
        {
            string email = txtRegEmail.Text.Trim();
            if (email.Length > 0 && !AuthService.IsValidEmail(email))
            {
                SetError(lblRegEmailError, "Invalid email format.");
                return false;
            }
            SetError(lblRegEmailError, "");
            return true;
        }

        private void txtRegPassword_TextChanged(object sender, EventArgs e)
        {
            UpdatePasswordStrength(txtRegPassword.Text);
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private void UpdatePasswordStrength(string password)
        {
            var strength = AuthService.CalculatePasswordStrength(password);
            switch (strength)
            {
                case PasswordStrength.None:
                    lblRegPasswordStrength.Text = "";
                    break;
                case PasswordStrength.Weak:
                    lblRegPasswordStrength.Text = "● Weak";
                    lblRegPasswordStrength.ForeColor = Color.FromArgb(210, 50, 50);
                    break;
                case PasswordStrength.Medium:
                    lblRegPasswordStrength.Text = "● Medium";
                    lblRegPasswordStrength.ForeColor = Color.FromArgb(234, 88, 12);
                    break;
                case PasswordStrength.Strong:
                    lblRegPasswordStrength.Text = "● Strong";
                    lblRegPasswordStrength.ForeColor = Color.FromArgb(22, 163, 74);
                    break;
            }
        }

        private void txtRegPasswordConfirm_Leave(object sender, EventArgs e) => ValidatePasswordConfirm();

        private void txtRegPasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            if (lblRegPasswordConfirmError.Visible) SetError(lblRegPasswordConfirmError, "");
            if (lblRegisterError.Visible) SetError(lblRegisterError, "");
        }

        private bool ValidatePasswordConfirm()
        {
            if (txtRegPasswordConfirm.Text != txtRegPassword.Text)
            {
                SetError(lblRegPasswordConfirmError, "Passwords do not match.");
                return false;
            }
            SetError(lblRegPasswordConfirmError, "");
            return true;
        }

        private void btnShowLoginPassword_Click(object sender, EventArgs e)
        {
            bool isHidden = txtLoginPassword.UseSystemPasswordChar;
            txtLoginPassword.UseSystemPasswordChar = !isHidden;
            btnShowLoginPassword.IconChar = isHidden ? FontAwesome.Sharp.IconChar.EyeSlash : FontAwesome.Sharp.IconChar.Eye;
        }

        private void btnShowRegPassword_Click(object sender, EventArgs e)
        {
            bool isHidden = txtRegPassword.UseSystemPasswordChar;
            txtRegPassword.UseSystemPasswordChar = !isHidden;
            btnShowRegPassword.IconChar = isHidden ? FontAwesome.Sharp.IconChar.EyeSlash : FontAwesome.Sharp.IconChar.Eye;
        }

        private void btnShowRegPasswordConfirm_Click(object sender, EventArgs e)
        {
            bool isHidden = txtRegPasswordConfirm.UseSystemPasswordChar;
            txtRegPasswordConfirm.UseSystemPasswordChar = !isHidden;
            btnShowRegPasswordConfirm.IconChar = isHidden ? FontAwesome.Sharp.IconChar.EyeSlash : FontAwesome.Sharp.IconChar.Eye;
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(btnLogin, false, "Sign In", "Signing in…");
            }
        }

        // ─── Register submit (async + loading state) ────

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
                    txtRegPasswordConfirm.Text = "";    
                    lblRegPasswordStrength.Text = "";   

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(btnRegister, false, "Create Account", "Creating account…");
            }
        }

        // UI Polish - Card Panel Borders
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
    }
}

