namespace LibraryManagement
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoginRegister = new System.Windows.Forms.Button();
            this.btnManageBooks = new System.Windows.Forms.Button();
            this.btnManageReaders = new System.Windows.Forms.Button();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblSidebarAppTitle = new System.Windows.Forms.Label();
            this.lblSidebarSubtitle = new System.Windows.Forms.Label();
            this.lblSidebarIcon = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblSessionStatus = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoginRegister
            // 
            this.btnLoginRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLoginRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoginRegister.FlatAppearance.BorderSize = 0;
            this.btnLoginRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginRegister.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLoginRegister.ForeColor = System.Drawing.Color.White;
            this.btnLoginRegister.Location = new System.Drawing.Point(380, 20);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(160, 42);
            this.btnLoginRegister.TabIndex = 0;
            this.btnLoginRegister.Text = "Login / Register";
            this.btnLoginRegister.UseVisualStyleBackColor = false;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginOrLogout_Click);
            // 
            // btnManageBooks
            // 
            this.btnManageBooks.BackColor = System.Drawing.Color.White;
            this.btnManageBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageBooks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.btnManageBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageBooks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnManageBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.btnManageBooks.Location = new System.Drawing.Point(40, 40);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Size = new System.Drawing.Size(220, 80);
            this.btnManageBooks.TabIndex = 1;
            this.btnManageBooks.Text = "Manage Books";
            this.btnManageBooks.UseVisualStyleBackColor = false;
            this.btnManageBooks.Click += new System.EventHandler(this.btnManageBooks_Click);
            // 
            // btnManageReaders
            // 
            this.btnManageReaders.BackColor = System.Drawing.Color.White;
            this.btnManageReaders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageReaders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.btnManageReaders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageReaders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnManageReaders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.btnManageReaders.Location = new System.Drawing.Point(290, 40);
            this.btnManageReaders.Name = "btnManageReaders";
            this.btnManageReaders.Size = new System.Drawing.Size(220, 80);
            this.btnManageReaders.TabIndex = 2;
            this.btnManageReaders.Text = "Manage Readers";
            this.btnManageReaders.UseVisualStyleBackColor = false;
            this.btnManageReaders.Click += new System.EventHandler(this.btnManageReaders_Click);
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.BackColor = System.Drawing.Color.White;
            this.btnBorrowBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrowBook.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.btnBorrowBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowBook.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBorrowBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.btnBorrowBook.Location = new System.Drawing.Point(40, 150);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(220, 80);
            this.btnBorrowBook.TabIndex = 3;
            this.btnBorrowBook.Text = "Borrow Book";
            this.btnBorrowBook.UseVisualStyleBackColor = false;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.White;
            this.btnReturnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnBook.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReturnBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.btnReturnBook.Location = new System.Drawing.Point(290, 150);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(220, 80);
            this.btnReturnBook.TabIndex = 4;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.btnExit.Location = new System.Drawing.Point(40, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.pnlSidebar.Controls.Add(this.lblSidebarAppTitle);
            this.pnlSidebar.Controls.Add(this.lblSidebarSubtitle);
            this.pnlSidebar.Controls.Add(this.lblSidebarIcon);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 520);
            this.pnlSidebar.TabIndex = 10;
            // 
            // lblSidebarAppTitle
            // 
            this.lblSidebarAppTitle.AutoSize = true;
            this.lblSidebarAppTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSidebarAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblSidebarAppTitle.Location = new System.Drawing.Point(12, 100);
            this.lblSidebarAppTitle.Name = "lblSidebarAppTitle";
            this.lblSidebarAppTitle.Size = new System.Drawing.Size(208, 37);
            this.lblSidebarAppTitle.TabIndex = 11;
            this.lblSidebarAppTitle.Text = "Library System";
            // 
            // lblSidebarSubtitle
            // 
            this.lblSidebarSubtitle.AutoSize = true;
            this.lblSidebarSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSidebarSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(220)))));
            this.lblSidebarSubtitle.Location = new System.Drawing.Point(14, 137);
            this.lblSidebarSubtitle.Name = "lblSidebarSubtitle";
            this.lblSidebarSubtitle.Size = new System.Drawing.Size(226, 42);
            this.lblSidebarSubtitle.TabIndex = 12;
            this.lblSidebarSubtitle.Text = "Manage your library efficiently \r\nand securely.";
            // 
            // lblSidebarIcon
            // 
            this.lblSidebarIcon.AutoSize = true;
            this.lblSidebarIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblSidebarIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.lblSidebarIcon.Location = new System.Drawing.Point(10, 40);
            this.lblSidebarIcon.Name = "lblSidebarIcon";
            this.lblSidebarIcon.Size = new System.Drawing.Size(92, 63);
            this.lblSidebarIcon.TabIndex = 10;
            this.lblSidebarIcon.Text = "📚";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlRight.Controls.Add(this.pnlContent);
            this.pnlRight.Controls.Add(this.pnlHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(230, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(570, 520);
            this.pnlRight.TabIndex = 11;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnReturnBook);
            this.pnlContent.Controls.Add(this.btnBorrowBook);
            this.pnlContent.Controls.Add(this.btnManageReaders);
            this.pnlContent.Controls.Add(this.btnManageBooks);
            this.pnlContent.Controls.Add(this.btnExit);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(570, 440);
            this.pnlContent.TabIndex = 15;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblSessionStatus);
            this.pnlHeader.Controls.Add(this.btnLoginRegister);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(570, 80);
            this.pnlHeader.TabIndex = 12;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(24, 24);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(179, 41);
            this.lblHeaderTitle.TabIndex = 13;
            this.lblHeaderTitle.Text = "Main Menu";
            // 
            // lblSessionStatus
            // 
            this.lblSessionStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSessionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblSessionStatus.Location = new System.Drawing.Point(149, 27);
            this.lblSessionStatus.Name = "lblSessionStatus";
            this.lblSessionStatus.Size = new System.Drawing.Size(200, 29);
            this.lblSessionStatus.TabIndex = 14;
            this.lblSessionStatus.Text = "Not signed in";
            this.lblSessionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library System - Main Menu";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Original buttons updated with new UX
        private System.Windows.Forms.Button btnLoginRegister;
        private System.Windows.Forms.Button btnManageBooks;
        private System.Windows.Forms.Button btnManageReaders;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnExit;

        // New Layout Containers
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarAppTitle;
        private System.Windows.Forms.Label lblSidebarSubtitle;
        private System.Windows.Forms.Label lblSidebarIcon;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblSessionStatus;
        private System.Windows.Forms.Panel pnlContent;
    }
}

