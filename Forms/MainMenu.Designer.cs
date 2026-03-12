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
            this.SuspendLayout();
            // 
            // btnLoginRegister
            // 
            this.btnLoginRegister.Location = new System.Drawing.Point(186, 28);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(112, 49);
            this.btnLoginRegister.TabIndex = 0;
            this.btnLoginRegister.Text = "Login/Register";
            this.btnLoginRegister.UseVisualStyleBackColor = true;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginOrLogout_Click);
            // 
            // btnManageBooks
            // 
            this.btnManageBooks.Location = new System.Drawing.Point(266, 219);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Size = new System.Drawing.Size(189, 58);
            this.btnManageBooks.TabIndex = 2;
            this.btnManageBooks.Text = "Manage Books";
            this.btnManageBooks.UseVisualStyleBackColor = true;
            this.btnManageBooks.Click += new System.EventHandler(this.btnManageBooks_Click);
            // 
            // btnManageReaders
            // 
            this.btnManageReaders.Location = new System.Drawing.Point(266, 122);
            this.btnManageReaders.Name = "btnManageReaders";
            this.btnManageReaders.Size = new System.Drawing.Size(189, 58);
            this.btnManageReaders.TabIndex = 3;
            this.btnManageReaders.Text = "Manage Readers";
            this.btnManageReaders.UseVisualStyleBackColor = true;
            this.btnManageReaders.Click += new System.EventHandler(this.btnManageReaders_Click);
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.Location = new System.Drawing.Point(56, 122);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(189, 58);
            this.btnBorrowBook.TabIndex = 4;
            this.btnBorrowBook.Text = "Borrow Book";
            this.btnBorrowBook.UseVisualStyleBackColor = true;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(56, 219);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(189, 58);
            this.btnReturnBook.TabIndex = 5;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(186, 318);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 44);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 466);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnBorrowBook);
            this.Controls.Add(this.btnManageReaders);
            this.Controls.Add(this.btnManageBooks);
            this.Controls.Add(this.btnLoginRegister);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoginRegister;
        private System.Windows.Forms.Button btnManageBooks;
        private System.Windows.Forms.Button btnManageReaders;
        private System.Windows.Forms.Button btnBorrowBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnExit;
    }
}

