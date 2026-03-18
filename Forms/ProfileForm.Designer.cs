namespace LibraryManagement
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnBackToMenu = new FontAwesome.Sharp.IconButton();
            this.lblNavProfile = new System.Windows.Forms.Label();
            this.iconNavProfile = new FontAwesome.Sharp.IconPictureBox();
            this.pnlNavSeparator = new System.Windows.Forms.Panel();
            this.lblAppSubtitle = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.iconSidebar = new FontAwesome.Sharp.IconPictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlProfileCard = new System.Windows.Forms.Panel();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblDisplayRole = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblErrFirstName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblErrPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblErrAddress = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmailNote = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNavProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSidebar)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlProfileCard.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.pnlSidebar.Controls.Add(this.btnBackToMenu);
            this.pnlSidebar.Controls.Add(this.lblNavProfile);
            this.pnlSidebar.Controls.Add(this.iconNavProfile);
            this.pnlSidebar.Controls.Add(this.pnlNavSeparator);
            this.pnlSidebar.Controls.Add(this.lblAppSubtitle);
            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Controls.Add(this.iconSidebar);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 617);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnBackToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToMenu.FlatAppearance.BorderSize = 0;
            this.btnBackToMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(85)))));
            this.btnBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBackToMenu.ForeColor = System.Drawing.Color.White;
            this.btnBackToMenu.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBackToMenu.IconColor = System.Drawing.Color.White;
            this.btnBackToMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBackToMenu.IconSize = 16;
            this.btnBackToMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackToMenu.Location = new System.Drawing.Point(6, 235);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.btnBackToMenu.Size = new System.Drawing.Size(190, 58);
            this.btnBackToMenu.TabIndex = 0;
            this.btnBackToMenu.Text = "Back to Menu";
            this.btnBackToMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackToMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackToMenu.UseVisualStyleBackColor = false;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // lblNavProfile
            // 
            this.lblNavProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNavProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.lblNavProfile.Location = new System.Drawing.Point(44, 202);
            this.lblNavProfile.Name = "lblNavProfile";
            this.lblNavProfile.Size = new System.Drawing.Size(166, 30);
            this.lblNavProfile.TabIndex = 1;
            this.lblNavProfile.Text = "My Profile";
            this.lblNavProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconNavProfile
            // 
            this.iconNavProfile.BackColor = System.Drawing.Color.Transparent;
            this.iconNavProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.iconNavProfile.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconNavProfile.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.iconNavProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNavProfile.IconSize = 24;
            this.iconNavProfile.Location = new System.Drawing.Point(20, 205);
            this.iconNavProfile.Name = "iconNavProfile";
            this.iconNavProfile.Size = new System.Drawing.Size(24, 24);
            this.iconNavProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconNavProfile.TabIndex = 2;
            this.iconNavProfile.TabStop = false;
            // 
            // pnlNavSeparator
            // 
            this.pnlNavSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(234)))), ((int)(((byte)(240)))));
            this.pnlNavSeparator.Location = new System.Drawing.Point(20, 180);
            this.pnlNavSeparator.Name = "pnlNavSeparator";
            this.pnlNavSeparator.Size = new System.Drawing.Size(190, 1);
            this.pnlNavSeparator.TabIndex = 3;
            // 
            // lblAppSubtitle
            // 
            this.lblAppSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(220)))));
            this.lblAppSubtitle.Location = new System.Drawing.Point(0, 130);
            this.lblAppSubtitle.Name = "lblAppSubtitle";
            this.lblAppSubtitle.Size = new System.Drawing.Size(230, 30);
            this.lblAppSubtitle.TabIndex = 4;
            this.lblAppSubtitle.Text = "Librarian Portal";
            this.lblAppSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(0, 100);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(230, 30);
            this.lblAppName.TabIndex = 5;
            this.lblAppName.Text = "Library System";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconSidebar
            // 
            this.iconSidebar.BackColor = System.Drawing.Color.Transparent;
            this.iconSidebar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.iconSidebar.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.iconSidebar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.iconSidebar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSidebar.IconSize = 60;
            this.iconSidebar.Location = new System.Drawing.Point(0, 40);
            this.iconSidebar.Name = "iconSidebar";
            this.iconSidebar.Size = new System.Drawing.Size(230, 60);
            this.iconSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconSidebar.TabIndex = 6;
            this.iconSidebar.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlRight.Controls.Add(this.pnlProfileCard);
            this.pnlRight.Controls.Add(this.pnlHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(230, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(570, 617);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlProfileCard
            // 
            this.pnlProfileCard.BackColor = System.Drawing.Color.White;
            this.pnlProfileCard.Controls.Add(this.pnlAvatar);
            this.pnlProfileCard.Controls.Add(this.lblDisplayName);
            this.pnlProfileCard.Controls.Add(this.lblDisplayRole);
            this.pnlProfileCard.Controls.Add(this.lblFirstName);
            this.pnlProfileCard.Controls.Add(this.txtFirstName);
            this.pnlProfileCard.Controls.Add(this.lblErrFirstName);
            this.pnlProfileCard.Controls.Add(this.lblPhone);
            this.pnlProfileCard.Controls.Add(this.txtPhone);
            this.pnlProfileCard.Controls.Add(this.lblErrPhone);
            this.pnlProfileCard.Controls.Add(this.lblAddress);
            this.pnlProfileCard.Controls.Add(this.txtAddress);
            this.pnlProfileCard.Controls.Add(this.lblErrAddress);
            this.pnlProfileCard.Controls.Add(this.lblEmail);
            this.pnlProfileCard.Controls.Add(this.txtEmail);
            this.pnlProfileCard.Controls.Add(this.lblEmailNote);
            this.pnlProfileCard.Controls.Add(this.lblFeedback);
            this.pnlProfileCard.Controls.Add(this.btnEdit);
            this.pnlProfileCard.Controls.Add(this.btnSave);
            this.pnlProfileCard.Controls.Add(this.btnCancel);
            this.pnlProfileCard.Location = new System.Drawing.Point(57, 100);
            this.pnlProfileCard.Name = "pnlProfileCard";
            this.pnlProfileCard.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
            this.pnlProfileCard.Size = new System.Drawing.Size(440, 495);
            this.pnlProfileCard.TabIndex = 0;
            this.pnlProfileCard.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BackColor = System.Drawing.Color.White;
            this.pnlAvatar.Controls.Add(this.lblAvatar);
            this.pnlAvatar.Location = new System.Drawing.Point(30, 25);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(64, 64);
            this.pnlAvatar.TabIndex = 0;
            this.pnlAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAvatar_Paint);
            // 
            // lblAvatar
            // 
            this.lblAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(0, 0);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(64, 64);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "JS";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvatar.Visible = false;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblDisplayName.Location = new System.Drawing.Point(110, 30);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(141, 32);
            this.lblDisplayName.TabIndex = 1;
            this.lblDisplayName.Text = "John Smith";
            // 
            // lblDisplayRole
            // 
            this.lblDisplayRole.AutoSize = true;
            this.lblDisplayRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDisplayRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblDisplayRole.Location = new System.Drawing.Point(112, 60);
            this.lblDisplayRole.Name = "lblDisplayRole";
            this.lblDisplayRole.Size = new System.Drawing.Size(72, 21);
            this.lblDisplayRole.TabIndex = 2;
            this.lblDisplayRole.Text = "Librarian";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblFirstName.Location = new System.Drawing.Point(30, 123);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(76, 20);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "Full Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(140, 120);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(290, 30);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            this.txtFirstName.Enter += new System.EventHandler(this.txtFirstName_EnterFocus);
            this.txtFirstName.Leave += new System.EventHandler(this.txtFirstName_LeaveFocus);            // 
            // lblErrFirstName
            // 
            this.lblErrFirstName.AutoSize = true;
            this.lblErrFirstName.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblErrFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblErrFirstName.Location = new System.Drawing.Point(140, 150);
            this.lblErrFirstName.Name = "lblErrFirstName";
            this.lblErrFirstName.Size = new System.Drawing.Size(0, 19);
            this.lblErrFirstName.TabIndex = 4;
            this.lblErrFirstName.Visible = false;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblPhone.Location = new System.Drawing.Point(30, 233);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(108, 20);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone Number";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(140, 230);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(290, 30);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_EnterFocus);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_LeaveFocus);            // 
            // lblErrPhone
            // 
            this.lblErrPhone.AutoSize = true;
            this.lblErrPhone.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblErrPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblErrPhone.Location = new System.Drawing.Point(140, 260);
            this.lblErrPhone.Name = "lblErrPhone";
            this.lblErrPhone.Size = new System.Drawing.Size(0, 19);
            this.lblErrPhone.TabIndex = 6;
            this.lblErrPhone.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblAddress.Location = new System.Drawing.Point(30, 288);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 20);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(140, 285);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(290, 80);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_EnterFocus);
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_LeaveFocus);            // 
            // lblErrAddress
            // 
            this.lblErrAddress.AutoSize = true;
            this.lblErrAddress.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblErrAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblErrAddress.Location = new System.Drawing.Point(140, 347);
            this.lblErrAddress.Name = "lblErrAddress";
            this.lblErrAddress.Size = new System.Drawing.Size(0, 19);
            this.lblErrAddress.TabIndex = 8;
            this.lblErrAddress.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblEmail.Location = new System.Drawing.Point(30, 178);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(103, 20);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email Address";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(140, 175);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(290, 30);
            this.txtEmail.TabIndex = 1;            // 
            // lblEmailNote
            // 
            this.lblEmailNote.AutoSize = true;
            this.lblEmailNote.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEmailNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblEmailNote.Location = new System.Drawing.Point(140, 205);
            this.lblEmailNote.Name = "lblEmailNote";
            this.lblEmailNote.Size = new System.Drawing.Size(165, 19);
            this.lblEmailNote.TabIndex = 10;
            this.lblEmailNote.Text = "Email cannot be changed.";
            // 
            // lblFeedback
            // 
            this.lblFeedback.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFeedback.Location = new System.Drawing.Point(30, 365);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblFeedback.Size = new System.Drawing.Size(400, 30);
            this.lblFeedback.TabIndex = 11;
            this.lblFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFeedback.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEdit.IconColor = System.Drawing.Color.White;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.IconSize = 16;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(30, 405);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(140, 42);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit Profile";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 42);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(230)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnCancel.Location = new System.Drawing.Point(180, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.lblPageSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(570, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 20);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(151, 37);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "My Profile";
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(27, 52);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(265, 20);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "View and manage your account details";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Profile — Library System";
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconNavProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSidebar)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlProfileCard.ResumeLayout(false);
            this.pnlProfileCard.PerformLayout();
            this.pnlAvatar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private FontAwesome.Sharp.IconPictureBox iconSidebar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppSubtitle;
        private System.Windows.Forms.Panel pnlNavSeparator;
        private FontAwesome.Sharp.IconPictureBox iconNavProfile;
        private System.Windows.Forms.Label lblNavProfile;
        private FontAwesome.Sharp.IconButton btnBackToMenu;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;

        private System.Windows.Forms.Panel pnlProfileCard;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblDisplayRole;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblErrFirstName;

        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblErrPhone;

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblErrAddress;

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEmailNote;

        private System.Windows.Forms.Label lblFeedback;

        private FontAwesome.Sharp.IconButton btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}





