namespace LibraryManagement
{
    partial class LoginRegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── Sidebar (left column) ──────────────────────────────────────────────
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblAppSubtitle = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblBookIcon = new System.Windows.Forms.Label();

            // ── Right column host ──────────────────────────────────────────────────
            this.pnlRight = new System.Windows.Forms.Panel();

            // ── Login card ────────────────────────────────────────────────────────
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnGoToRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLoginError = new System.Windows.Forms.Label();
            this.chkShowLoginPassword = new System.Windows.Forms.CheckBox();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.lblLoginEmailError = new System.Windows.Forms.Label();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.lblLoginEmail = new System.Windows.Forms.Label();
            this.lblLoginSubtitle = new System.Windows.Forms.Label();
            this.lblLoginTitle = new System.Windows.Forms.Label();

            // ── Register card ─────────────────────────────────────────────────────
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.btnGoToLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblRegisterError = new System.Windows.Forms.Label();
            this.lblRegPasswordConfirmError = new System.Windows.Forms.Label();
            this.chkShowRegPasswordConfirm = new System.Windows.Forms.CheckBox();
            this.txtRegPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lblRegPasswordConfirm = new System.Windows.Forms.Label();
            this.lblRegPasswordStrength = new System.Windows.Forms.Label();
            this.chkShowRegPassword = new System.Windows.Forms.CheckBox();
            this.txtRegPassword = new System.Windows.Forms.TextBox();
            this.lblRegPassword = new System.Windows.Forms.Label();
            this.lblRegEmailError = new System.Windows.Forms.Label();
            this.txtRegEmail = new System.Windows.Forms.TextBox();
            this.lblRegEmail = new System.Windows.Forms.Label();
            this.txtRegName = new System.Windows.Forms.TextBox();
            this.lblRegName = new System.Windows.Forms.Label();
            this.lblRegSubtitle = new System.Windows.Forms.Label();
            this.lblRegTitle = new System.Windows.Forms.Label();

            this.pnlSidebar.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlRegister.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════════════
            // pnlSidebar
            // ══════════════════════════════════════════════════════════════════════
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(22, 43, 75);
            this.pnlSidebar.Controls.Add(this.lblBookIcon);
            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Controls.Add(this.lblAppSubtitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Width = 230;

            // lblBookIcon
            this.lblBookIcon.AutoSize = false;
            this.lblBookIcon.ForeColor = System.Drawing.Color.FromArgb(92, 179, 255);
            this.lblBookIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 42F);
            this.lblBookIcon.Location = new System.Drawing.Point(0, 110);
            this.lblBookIcon.Size = new System.Drawing.Size(230, 80);
            this.lblBookIcon.Text = "📚";
            this.lblBookIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBookIcon.Name = "lblBookIcon";

            // lblAppName
            this.lblAppName.AutoSize = false;
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppName.Location = new System.Drawing.Point(10, 200);
            this.lblAppName.Size = new System.Drawing.Size(210, 40);
            this.lblAppName.Text = "Library System";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppName.Name = "lblAppName";

            // lblAppSubtitle
            this.lblAppSubtitle.AutoSize = false;
            this.lblAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 190, 220);
            this.lblAppSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAppSubtitle.Location = new System.Drawing.Point(15, 245);
            this.lblAppSubtitle.Size = new System.Drawing.Size(200, 50);
            this.lblAppSubtitle.Text = "Manage your library\r\nefficiently & securely";
            this.lblAppSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAppSubtitle.Name = "lblAppSubtitle";

            // ══════════════════════════════════════════════════════════════════════
            // pnlRight
            // ══════════════════════════════════════════════════════════════════════
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlRight.Controls.Add(this.pnlLogin);
            this.pnlRight.Controls.Add(this.pnlRegister);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Name = "pnlRight";

            // ══════════════════════════════════════════════════════════════════════
            // pnlLogin  (card centered in pnlRight)
            // ══════════════════════════════════════════════════════════════════════
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.Controls.Add(this.lblLoginTitle);
            this.pnlLogin.Controls.Add(this.lblLoginSubtitle);
            this.pnlLogin.Controls.Add(this.lblLoginEmail);
            this.pnlLogin.Controls.Add(this.txtLoginEmail);
            this.pnlLogin.Controls.Add(this.lblLoginEmailError);
            this.pnlLogin.Controls.Add(this.lblLoginPassword);
            this.pnlLogin.Controls.Add(this.txtLoginPassword);
            this.pnlLogin.Controls.Add(this.chkShowLoginPassword);
            this.pnlLogin.Controls.Add(this.lblLoginError);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.btnGoToRegister);
            this.pnlLogin.Location = new System.Drawing.Point(30, 25);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(360, 480);
            this.pnlLogin.TabIndex = 0;

            // lblLoginTitle
            this.lblLoginTitle.AutoSize = false;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoginTitle.ForeColor = System.Drawing.Color.FromArgb(22, 43, 75);
            this.lblLoginTitle.Location = new System.Drawing.Point(30, 30);
            this.lblLoginTitle.Size = new System.Drawing.Size(300, 40);
            this.lblLoginTitle.Text = "Welcome Back";
            this.lblLoginTitle.Name = "lblLoginTitle";

            // lblLoginSubtitle
            this.lblLoginSubtitle.AutoSize = false;
            this.lblLoginSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLoginSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            this.lblLoginSubtitle.Location = new System.Drawing.Point(30, 72);
            this.lblLoginSubtitle.Size = new System.Drawing.Size(300, 22);
            this.lblLoginSubtitle.Text = "Sign in to your account to continue";
            this.lblLoginSubtitle.Name = "lblLoginSubtitle";

            // ── Email ──
            this.lblLoginEmail.AutoSize = true;
            this.lblLoginEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoginEmail.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblLoginEmail.Location = new System.Drawing.Point(30, 115);
            this.lblLoginEmail.Name = "lblLoginEmail";
            this.lblLoginEmail.Text = "Email Address";

            this.txtLoginEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLoginEmail.Location = new System.Drawing.Point(30, 137);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(300, 30);
            this.txtLoginEmail.TabIndex = 0;
            this.txtLoginEmail.Leave += new System.EventHandler(this.txtLoginEmail_Leave);
            this.txtLoginEmail.TextChanged += new System.EventHandler(this.txtLoginEmail_TextChanged);

            this.lblLoginEmailError.AutoSize = true;
            this.lblLoginEmailError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLoginEmailError.ForeColor = System.Drawing.Color.FromArgb(210, 50, 50);
            this.lblLoginEmailError.Location = new System.Drawing.Point(30, 170);
            this.lblLoginEmailError.Name = "lblLoginEmailError";
            this.lblLoginEmailError.Text = "";
            this.lblLoginEmailError.Visible = false;

            // ── Password ──
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoginPassword.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblLoginPassword.Location = new System.Drawing.Point(30, 195);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Text = "Password";

            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLoginPassword.Location = new System.Drawing.Point(30, 217);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '●';
            this.txtLoginPassword.Size = new System.Drawing.Size(262, 30);
            this.txtLoginPassword.TabIndex = 1;
            this.txtLoginPassword.TextChanged += new System.EventHandler(this.txtLoginPassword_TextChanged);

            this.chkShowLoginPassword.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowLoginPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowLoginPassword.FlatAppearance.BorderSize = 0;
            this.chkShowLoginPassword.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.chkShowLoginPassword.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            this.chkShowLoginPassword.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.chkShowLoginPassword.Location = new System.Drawing.Point(296, 216);
            this.chkShowLoginPassword.Name = "chkShowLoginPassword";
            this.chkShowLoginPassword.Size = new System.Drawing.Size(34, 32);
            this.chkShowLoginPassword.TabIndex = 2;
            this.chkShowLoginPassword.Text = "👁";
            this.chkShowLoginPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowLoginPassword.UseVisualStyleBackColor = false;
            this.chkShowLoginPassword.CheckedChanged += new System.EventHandler(this.chkShowLoginPassword_CheckedChanged);

            // lblLoginError
            this.lblLoginError.AutoSize = false;
            this.lblLoginError.BackColor = System.Drawing.Color.FromArgb(255, 235, 235);
            this.lblLoginError.ForeColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.lblLoginError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLoginError.Location = new System.Drawing.Point(30, 260);
            this.lblLoginError.Name = "lblLoginError";
            this.lblLoginError.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblLoginError.Size = new System.Drawing.Size(300, 30);
            this.lblLoginError.Text = "";
            this.lblLoginError.Visible = false;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(30, 302);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(300, 42);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnGoToRegister
            this.btnGoToRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnGoToRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToRegister.FlatAppearance.BorderSize = 0;
            this.btnGoToRegister.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGoToRegister.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGoToRegister.Location = new System.Drawing.Point(30, 358);
            this.btnGoToRegister.Name = "btnGoToRegister";
            this.btnGoToRegister.Size = new System.Drawing.Size(300, 30);
            this.btnGoToRegister.TabIndex = 4;
            this.btnGoToRegister.Text = "Don't have an account?  Register →";
            this.btnGoToRegister.UseVisualStyleBackColor = false;
            this.btnGoToRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToRegister.Click += new System.EventHandler(this.btnGoToRegister_Click);

            // ══════════════════════════════════════════════════════════════════════
            // pnlRegister  (card centered in pnlRight)
            // ══════════════════════════════════════════════════════════════════════
            // Re-compacted registration card to 360 x 480 (same as pnlLogin)
            this.pnlRegister.BackColor = System.Drawing.Color.White;
            this.pnlRegister.Controls.Add(this.lblRegTitle);
            this.pnlRegister.Controls.Add(this.lblRegSubtitle);
            this.pnlRegister.Controls.Add(this.lblRegName);
            this.pnlRegister.Controls.Add(this.txtRegName);
            this.pnlRegister.Controls.Add(this.lblRegEmail);
            this.pnlRegister.Controls.Add(this.txtRegEmail);
            this.pnlRegister.Controls.Add(this.lblRegEmailError);
            this.pnlRegister.Controls.Add(this.lblRegPassword);
            this.pnlRegister.Controls.Add(this.txtRegPassword);
            this.pnlRegister.Controls.Add(this.chkShowRegPassword);
            this.pnlRegister.Controls.Add(this.lblRegPasswordStrength);
            this.pnlRegister.Controls.Add(this.lblRegPasswordConfirm);
            this.pnlRegister.Controls.Add(this.txtRegPasswordConfirm);
            this.pnlRegister.Controls.Add(this.chkShowRegPasswordConfirm);
            this.pnlRegister.Controls.Add(this.lblRegPasswordConfirmError);
            this.pnlRegister.Controls.Add(this.lblRegisterError);
            this.pnlRegister.Controls.Add(this.btnRegister);
            this.pnlRegister.Controls.Add(this.btnGoToLogin);
            this.pnlRegister.Location = new System.Drawing.Point(30, 25);
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(360, 480);
            this.pnlRegister.TabIndex = 1;

            // lblRegTitle
            this.lblRegTitle.AutoSize = false;
            this.lblRegTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblRegTitle.ForeColor = System.Drawing.Color.FromArgb(22, 43, 75);
            this.lblRegTitle.Location = new System.Drawing.Point(30, 20);
            this.lblRegTitle.Size = new System.Drawing.Size(300, 35);
            this.lblRegTitle.Text = "Create Account";
            this.lblRegTitle.Name = "lblRegTitle";

            // lblRegSubtitle
            this.lblRegSubtitle.AutoSize = false;
            this.lblRegSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145);
            this.lblRegSubtitle.Location = new System.Drawing.Point(30, 55);
            this.lblRegSubtitle.Size = new System.Drawing.Size(300, 20);
            this.lblRegSubtitle.Text = "Fill in the details to register";
            this.lblRegSubtitle.Name = "lblRegSubtitle";

            // ── Full Name ──
            this.lblRegName.AutoSize = true;
            this.lblRegName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRegName.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblRegName.Location = new System.Drawing.Point(30, 85);
            this.lblRegName.Name = "lblRegName";
            this.lblRegName.Text = "Full Name";

            this.txtRegName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRegName.Location = new System.Drawing.Point(30, 105);
            this.txtRegName.Name = "txtRegName";
            this.txtRegName.Size = new System.Drawing.Size(300, 28);
            this.txtRegName.TabIndex = 0;
            this.txtRegName.TextChanged += new System.EventHandler(this.txtRegName_TextChanged);

            // ── Email ──
            this.lblRegEmail.AutoSize = true;
            this.lblRegEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRegEmail.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblRegEmail.Location = new System.Drawing.Point(30, 142);
            this.lblRegEmail.Name = "lblRegEmail";
            this.lblRegEmail.Text = "Email Address";

            this.txtRegEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRegEmail.Location = new System.Drawing.Point(30, 162);
            this.txtRegEmail.Name = "txtRegEmail";
            this.txtRegEmail.Size = new System.Drawing.Size(300, 28);
            this.txtRegEmail.TabIndex = 1;
            this.txtRegEmail.Leave += new System.EventHandler(this.txtRegEmail_Leave);
            this.txtRegEmail.TextChanged += new System.EventHandler(this.txtRegEmail_TextChanged);

            this.lblRegEmailError.AutoSize = true;
            this.lblRegEmailError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRegEmailError.ForeColor = System.Drawing.Color.FromArgb(210, 50, 50);
            this.lblRegEmailError.Location = new System.Drawing.Point(30, 191);
            this.lblRegEmailError.Name = "lblRegEmailError";
            this.lblRegEmailError.Text = "";
            this.lblRegEmailError.Visible = false;

            // ── Password ──
            this.lblRegPassword.AutoSize = true;
            this.lblRegPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRegPassword.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblRegPassword.Location = new System.Drawing.Point(30, 198);
            this.lblRegPassword.Name = "lblRegPassword";
            this.lblRegPassword.Text = "Password";

            this.txtRegPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRegPassword.Location = new System.Drawing.Point(30, 218);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.PasswordChar = '●';
            this.txtRegPassword.Size = new System.Drawing.Size(262, 28);
            this.txtRegPassword.TabIndex = 2;
            this.txtRegPassword.TextChanged += new System.EventHandler(this.txtRegPassword_TextChanged);

            this.chkShowRegPassword.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowRegPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowRegPassword.FlatAppearance.BorderSize = 0;
            this.chkShowRegPassword.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.chkShowRegPassword.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            this.chkShowRegPassword.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.chkShowRegPassword.Location = new System.Drawing.Point(296, 217);
            this.chkShowRegPassword.Name = "chkShowRegPassword";
            this.chkShowRegPassword.Size = new System.Drawing.Size(34, 30);
            this.chkShowRegPassword.TabIndex = 3;
            this.chkShowRegPassword.Text = "👁";
            this.chkShowRegPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowRegPassword.UseVisualStyleBackColor = false;
            this.chkShowRegPassword.CheckedChanged += new System.EventHandler(this.chkShowRegPassword_CheckedChanged);

            // strength label
            this.lblRegPasswordStrength.AutoSize = true;
            this.lblRegPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRegPasswordStrength.Location = new System.Drawing.Point(30, 248);
            this.lblRegPasswordStrength.Name = "lblRegPasswordStrength";
            this.lblRegPasswordStrength.Text = "";

            // ── Confirm Password ──
            this.lblRegPasswordConfirm.AutoSize = true;
            this.lblRegPasswordConfirm.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRegPasswordConfirm.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblRegPasswordConfirm.Location = new System.Drawing.Point(30, 255);
            this.lblRegPasswordConfirm.Name = "lblRegPasswordConfirm";
            this.lblRegPasswordConfirm.Text = "Confirm Password";

            this.txtRegPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegPasswordConfirm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRegPasswordConfirm.Location = new System.Drawing.Point(30, 275);
            this.txtRegPasswordConfirm.Name = "txtRegPasswordConfirm";
            this.txtRegPasswordConfirm.PasswordChar = '●';
            this.txtRegPasswordConfirm.Size = new System.Drawing.Size(262, 28);
            this.txtRegPasswordConfirm.TabIndex = 4;
            this.txtRegPasswordConfirm.Leave += new System.EventHandler(this.txtRegPasswordConfirm_Leave);
            this.txtRegPasswordConfirm.TextChanged += new System.EventHandler(this.txtRegPasswordConfirm_TextChanged);

            this.chkShowRegPasswordConfirm.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowRegPasswordConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowRegPasswordConfirm.FlatAppearance.BorderSize = 0;
            this.chkShowRegPasswordConfirm.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.chkShowRegPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            this.chkShowRegPasswordConfirm.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.chkShowRegPasswordConfirm.Location = new System.Drawing.Point(296, 274);
            this.chkShowRegPasswordConfirm.Name = "chkShowRegPasswordConfirm";
            this.chkShowRegPasswordConfirm.Size = new System.Drawing.Size(34, 30);
            this.chkShowRegPasswordConfirm.TabIndex = 5;
            this.chkShowRegPasswordConfirm.Text = "👁";
            this.chkShowRegPasswordConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowRegPasswordConfirm.UseVisualStyleBackColor = false;
            this.chkShowRegPasswordConfirm.CheckedChanged += new System.EventHandler(this.chkShowRegPasswordConfirm_CheckedChanged);

            this.lblRegPasswordConfirmError.AutoSize = true;
            this.lblRegPasswordConfirmError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRegPasswordConfirmError.ForeColor = System.Drawing.Color.FromArgb(210, 50, 50);
            this.lblRegPasswordConfirmError.Location = new System.Drawing.Point(30, 306);
            this.lblRegPasswordConfirmError.Name = "lblRegPasswordConfirmError";
            this.lblRegPasswordConfirmError.Text = "";
            this.lblRegPasswordConfirmError.Visible = false;

            // lblRegisterError
            this.lblRegisterError.AutoSize = false;
            this.lblRegisterError.BackColor = System.Drawing.Color.FromArgb(255, 235, 235);
            this.lblRegisterError.ForeColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.lblRegisterError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRegisterError.Location = new System.Drawing.Point(30, 325);
            this.lblRegisterError.Name = "lblRegisterError";
            this.lblRegisterError.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblRegisterError.Size = new System.Drawing.Size(300, 30);
            this.lblRegisterError.Text = "";
            this.lblRegisterError.Visible = false;

            // btnRegister
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(30, 365);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(300, 42);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // btnGoToLogin
            this.btnGoToLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnGoToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToLogin.FlatAppearance.BorderSize = 0;
            this.btnGoToLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGoToLogin.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGoToLogin.Location = new System.Drawing.Point(30, 415);
            this.btnGoToLogin.Name = "btnGoToLogin";
            this.btnGoToLogin.Size = new System.Drawing.Size(300, 30);
            this.btnGoToLogin.TabIndex = 7;
            this.btnGoToLogin.Text = "Already have an account?  Sign In →";
            this.btnGoToLogin.UseVisualStyleBackColor = false;
            this.btnGoToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToLogin.Click += new System.EventHandler(this.btnGoToLogin_Click);

            // ══════════════════════════════════════════════════════════════════════
            // LoginRegisterForm
            // ══════════════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 520);    // Fixed, smaller size
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginRegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library System — Authentication";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegister.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Sidebar
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblBookIcon;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppSubtitle;
        // Right host
        private System.Windows.Forms.Panel pnlRight;
        // Login card
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.Label lblLoginSubtitle;
        private System.Windows.Forms.Label lblLoginEmail;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.Label lblLoginEmailError;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.CheckBox chkShowLoginPassword;
        private System.Windows.Forms.Label lblLoginError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGoToRegister;
        // Register card
        private System.Windows.Forms.Panel pnlRegister;
        private System.Windows.Forms.Label lblRegTitle;
        private System.Windows.Forms.Label lblRegSubtitle;
        private System.Windows.Forms.Label lblRegName;
        private System.Windows.Forms.TextBox txtRegName;
        private System.Windows.Forms.Label lblRegEmail;
        private System.Windows.Forms.TextBox txtRegEmail;
        private System.Windows.Forms.Label lblRegEmailError;
        private System.Windows.Forms.Label lblRegPassword;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.CheckBox chkShowRegPassword;
        private System.Windows.Forms.Label lblRegPasswordStrength;
        private System.Windows.Forms.Label lblRegPasswordConfirm;
        private System.Windows.Forms.TextBox txtRegPasswordConfirm;
        private System.Windows.Forms.CheckBox chkShowRegPasswordConfirm;
        private System.Windows.Forms.Label lblRegPasswordConfirmError;
        private System.Windows.Forms.Label lblRegisterError;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnGoToLogin;
    }
}