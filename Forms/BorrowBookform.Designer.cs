namespace LibraryManagement
{
    partial class BorrowBookform
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
            this.pnlBorrowCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblReaderId = new System.Windows.Forms.Label();
            this.cmbReader = new System.Windows.Forms.ComboBox();
            this.pbReaderAvatar = new System.Windows.Forms.PictureBox();
            this.lblReaderNameValue = new System.Windows.Forms.Label();
            this.lblReaderPhoneValue = new System.Windows.Forms.Label();
            this.lblReaderAddressValue = new System.Windows.Forms.Label();
            this.lblBookId = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.pbBookCover = new System.Windows.Forms.PictureBox();
            this.lblBookAuthorValue = new System.Windows.Forms.Label();
            this.lblBookIntegrityValue = new System.Windows.Forms.Label();
            this.lblDateExpire = new System.Windows.Forms.Label();
            this.dtpDateExpire = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBorrowCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReaderAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBorrowCard
            // 
            this.pnlBorrowCard.BackColor = System.Drawing.Color.White;
            this.pnlBorrowCard.Controls.Add(this.lblTitle);
            this.pnlBorrowCard.Controls.Add(this.lblReaderId);
            this.pnlBorrowCard.Controls.Add(this.cmbReader);
            this.pnlBorrowCard.Controls.Add(this.pbReaderAvatar);
            this.pnlBorrowCard.Controls.Add(this.lblReaderNameValue);
            this.pnlBorrowCard.Controls.Add(this.lblReaderPhoneValue);
            this.pnlBorrowCard.Controls.Add(this.lblReaderAddressValue);
            this.pnlBorrowCard.Controls.Add(this.lblBookId);
            this.pnlBorrowCard.Controls.Add(this.cmbBook);
            this.pnlBorrowCard.Controls.Add(this.pbBookCover);
            this.pnlBorrowCard.Controls.Add(this.lblBookAuthorValue);
            this.pnlBorrowCard.Controls.Add(this.lblBookIntegrityValue);
            this.pnlBorrowCard.Controls.Add(this.lblDateExpire);
            this.pnlBorrowCard.Controls.Add(this.dtpDateExpire);
            this.pnlBorrowCard.Controls.Add(this.btnSubmit);
            this.pnlBorrowCard.Controls.Add(this.btnCancel);
            this.pnlBorrowCard.Location = new System.Drawing.Point(31, 30);
            this.pnlBorrowCard.Name = "pnlBorrowCard";
            this.pnlBorrowCard.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
            this.pnlBorrowCard.Size = new System.Drawing.Size(582, 604);
            this.pnlBorrowCard.TabIndex = 0;
            this.pnlBorrowCard.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Issue Book";
            // 
            // lblReaderId
            // 
            this.lblReaderId.AutoSize = true;
            this.lblReaderId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReaderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblReaderId.Location = new System.Drawing.Point(30, 81);
            this.lblReaderId.Name = "lblReaderId";
            this.lblReaderId.Size = new System.Drawing.Size(58, 20);
            this.lblReaderId.TabIndex = 2;
            this.lblReaderId.Text = "Reader";
            // 
            // cmbReader
            // 
            this.cmbReader.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReader.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbReader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReader.Location = new System.Drawing.Point(30, 103);
            this.cmbReader.Name = "cmbReader";
            this.cmbReader.Size = new System.Drawing.Size(521, 31);
            this.cmbReader.TabIndex = 3;
            this.cmbReader.SelectedIndexChanged += new System.EventHandler(this.cmbReader_SelectedIndexChanged);
            // 
            // pbReaderAvatar
            // 
            this.pbReaderAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pbReaderAvatar.Location = new System.Drawing.Point(30, 140);
            this.pbReaderAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbReaderAvatar.Name = "pbReaderAvatar";
            this.pbReaderAvatar.Size = new System.Drawing.Size(75, 103);
            this.pbReaderAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbReaderAvatar.TabIndex = 10;
            this.pbReaderAvatar.TabStop = false;
            // 
            // lblReaderNameValue
            // 
            this.lblReaderNameValue.AutoSize = true;
            this.lblReaderNameValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReaderNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblReaderNameValue.Location = new System.Drawing.Point(111, 140);
            this.lblReaderNameValue.Name = "lblReaderNameValue";
            this.lblReaderNameValue.Size = new System.Drawing.Size(113, 21);
            this.lblReaderNameValue.TabIndex = 11;
            this.lblReaderNameValue.Text = "Reader Name";
            // 
            // lblReaderPhoneValue
            // 
            this.lblReaderPhoneValue.AutoSize = true;
            this.lblReaderPhoneValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReaderPhoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblReaderPhoneValue.Location = new System.Drawing.Point(111, 160);
            this.lblReaderPhoneValue.Name = "lblReaderPhoneValue";
            this.lblReaderPhoneValue.Size = new System.Drawing.Size(50, 20);
            this.lblReaderPhoneValue.TabIndex = 12;
            this.lblReaderPhoneValue.Text = "Phone";
            // 
            // lblReaderAddressValue
            // 
            this.lblReaderAddressValue.AutoSize = true;
            this.lblReaderAddressValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReaderAddressValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblReaderAddressValue.Location = new System.Drawing.Point(111, 180);
            this.lblReaderAddressValue.Name = "lblReaderAddressValue";
            this.lblReaderAddressValue.Size = new System.Drawing.Size(62, 20);
            this.lblReaderAddressValue.TabIndex = 13;
            this.lblReaderAddressValue.Text = "Address";
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblBookId.Location = new System.Drawing.Point(30, 245);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(96, 20);
            this.lblBookId.TabIndex = 4;
            this.lblBookId.Text = "Book (Copy)";
            // 
            // cmbBook
            // 
            this.cmbBook.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBook.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBook.Location = new System.Drawing.Point(30, 267);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(521, 31);
            this.cmbBook.TabIndex = 5;
            this.cmbBook.SelectedIndexChanged += new System.EventHandler(this.cmbBook_SelectedIndexChanged);
            // 
            // pbBookCover
            // 
            this.pbBookCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pbBookCover.Location = new System.Drawing.Point(30, 305);
            this.pbBookCover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbBookCover.Name = "pbBookCover";
            this.pbBookCover.Size = new System.Drawing.Size(75, 105);
            this.pbBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBookCover.TabIndex = 14;
            this.pbBookCover.TabStop = false;
            // 
            // lblBookAuthorValue
            // 
            this.lblBookAuthorValue.AutoSize = true;
            this.lblBookAuthorValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBookAuthorValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblBookAuthorValue.Location = new System.Drawing.Point(107, 305);
            this.lblBookAuthorValue.Name = "lblBookAuthorValue";
            this.lblBookAuthorValue.Size = new System.Drawing.Size(113, 21);
            this.lblBookAuthorValue.TabIndex = 15;
            this.lblBookAuthorValue.Text = "Author Name";
            // 
            // lblBookIntegrityValue
            // 
            this.lblBookIntegrityValue.AutoSize = true;
            this.lblBookIntegrityValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBookIntegrityValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblBookIntegrityValue.Location = new System.Drawing.Point(107, 330);
            this.lblBookIntegrityValue.Name = "lblBookIntegrityValue";
            this.lblBookIntegrityValue.Size = new System.Drawing.Size(71, 21);
            this.lblBookIntegrityValue.TabIndex = 19;
            this.lblBookIntegrityValue.Text = "Integrity:";
            // 
            // lblDateExpire
            // 
            this.lblDateExpire.AutoSize = true;
            this.lblDateExpire.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateExpire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblDateExpire.Location = new System.Drawing.Point(30, 412);
            this.lblDateExpire.Name = "lblDateExpire";
            this.lblDateExpire.Size = new System.Drawing.Size(94, 20);
            this.lblDateExpire.TabIndex = 6;
            this.lblDateExpire.Text = "Return Date";
            // 
            // dtpDateExpire
            // 
            this.dtpDateExpire.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateExpire.Location = new System.Drawing.Point(30, 434);
            this.dtpDateExpire.Name = "dtpDateExpire";
            this.dtpDateExpire.Size = new System.Drawing.Size(521, 30);
            this.dtpDateExpire.TabIndex = 7;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(142, 482);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(300, 42);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Issue Book";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.btnCancel.Location = new System.Drawing.Point(142, 541);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(300, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BorrowBookform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(640, 664);
            this.Controls.Add(this.pnlBorrowCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorrowBookform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Book";
            this.pnlBorrowCard.ResumeLayout(false);
            this.pnlBorrowCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReaderAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorrowCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReaderId;
        private System.Windows.Forms.ComboBox cmbReader;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label lblDateExpire;
        private System.Windows.Forms.DateTimePicker dtpDateExpire;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        
        private System.Windows.Forms.PictureBox pbReaderAvatar;
        private System.Windows.Forms.Label lblReaderNameValue;
        private System.Windows.Forms.Label lblReaderPhoneValue;
        private System.Windows.Forms.Label lblReaderAddressValue;
        private System.Windows.Forms.PictureBox pbBookCover;
        private System.Windows.Forms.Label lblBookAuthorValue;
        private System.Windows.Forms.Label lblBookIntegrityValue;
    }
}