namespace LibraryManagement
{
    partial class ReturnBookform
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
            this.pnlReturnCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblReaderId = new System.Windows.Forms.Label();
            this.cmbReader = new System.Windows.Forms.ComboBox();
            this.lblBookId = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.pbReaderAvatar = new System.Windows.Forms.PictureBox();
            this.lblReaderNameValue = new System.Windows.Forms.Label();
            this.lblReaderPhoneValue = new System.Windows.Forms.Label();
            this.lblReaderAddressValue = new System.Windows.Forms.Label();
            this.pbBookCover = new System.Windows.Forms.PictureBox();
            this.lblBookAuthorValue = new System.Windows.Forms.Label();
            this.lblReturnStatus = new System.Windows.Forms.Label();
            this.lblReturnStatusValue = new System.Windows.Forms.Label();
            this.lblIntegrityInput = new System.Windows.Forms.Label();
            this.nudIntegrity = new System.Windows.Forms.NumericUpDown();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblReturnStatus = new System.Windows.Forms.Label();
            this.lblReturnStatusValue = new System.Windows.Forms.Label();
            this.pnlReturnCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReaderAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrity)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlReturnCard
            // 
            this.pnlReturnCard.BackColor = System.Drawing.Color.White;
            this.pnlReturnCard.Controls.Add(this.lblTitle);
            this.pnlReturnCard.Controls.Add(this.lblReaderId);
            this.pnlReturnCard.Controls.Add(this.cmbReader);
            this.pnlReturnCard.Controls.Add(this.lblBookId);
            this.pnlReturnCard.Controls.Add(this.cmbBook);
            this.pnlReturnCard.Controls.Add(this.pbReaderAvatar);
            this.pnlReturnCard.Controls.Add(this.lblReaderNameValue);
            this.pnlReturnCard.Controls.Add(this.lblReaderPhoneValue);
            this.pnlReturnCard.Controls.Add(this.lblReaderAddressValue);
            this.pnlReturnCard.Controls.Add(this.pbBookCover);
            this.pnlReturnCard.Controls.Add(this.lblBookAuthorValue);
            this.pnlReturnCard.Controls.Add(this.lblReturnStatus);
            this.pnlReturnCard.Controls.Add(this.lblReturnStatusValue);
            this.pnlReturnCard.Controls.Add(this.lblIntegrityInput);
            this.pnlReturnCard.Controls.Add(this.nudIntegrity);
            this.pnlReturnCard.Controls.Add(this.btnSubmit);
            this.pnlReturnCard.Controls.Add(this.btnCancel);
            this.pnlReturnCard.Location = new System.Drawing.Point(31, 30);
            this.pnlReturnCard.Name = "pnlReturnCard";
            this.pnlReturnCard.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
            this.pnlReturnCard.Size = new System.Drawing.Size(582, 630);
            this.pnlReturnCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Return Book";
            // 
            // lblReaderId
            // 
            this.lblReaderId.AutoSize = true;
            this.lblReaderId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReaderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblReaderId.Location = new System.Drawing.Point(30, 105);
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
            this.cmbReader.Location = new System.Drawing.Point(30, 127);
            this.cmbReader.Name = "cmbReader";
            this.cmbReader.Size = new System.Drawing.Size(521, 31);
            this.cmbReader.TabIndex = 3;
            this.cmbReader.SelectedIndexChanged += new System.EventHandler(this.cmbReader_SelectedIndexChanged);
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblBookId.Location = new System.Drawing.Point(30, 266);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(169, 20);
            this.lblBookId.TabIndex = 4;
            this.lblBookId.Text = "Borrowed Book (Copy)";
            // 
            // cmbBook
            // 
            this.cmbBook.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBook.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBook.Location = new System.Drawing.Point(30, 288);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(521, 31);
            this.cmbBook.TabIndex = 5;
            this.cmbBook.SelectedIndexChanged += new System.EventHandler(this.cmbBook_SelectedIndexChanged);
            // 
            // pbReaderAvatar
            // 
            this.pbReaderAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pbReaderAvatar.Location = new System.Drawing.Point(30, 165);
            this.pbReaderAvatar.Name = "pbReaderAvatar";
            this.pbReaderAvatar.Size = new System.Drawing.Size(75, 100);
            this.pbReaderAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbReaderAvatar.TabIndex = 10;
            this.pbReaderAvatar.TabStop = false;
            // 
            // lblReaderNameValue
            // 
            this.lblReaderNameValue.AutoSize = true;
            this.lblReaderNameValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReaderNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblReaderNameValue.Location = new System.Drawing.Point(120, 165);
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
            this.lblReaderPhoneValue.Location = new System.Drawing.Point(120, 190);
            this.lblReaderPhoneValue.Name = "lblReaderPhoneValue";
            this.lblReaderPhoneValue.Size = new System.Drawing.Size(57, 20);
            this.lblReaderPhoneValue.TabIndex = 12;
            this.lblReaderPhoneValue.Text = "Phone: ";
            // 
            // lblReaderAddressValue
            // 
            this.lblReaderAddressValue.AutoSize = true;
            this.lblReaderAddressValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReaderAddressValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblReaderAddressValue.Location = new System.Drawing.Point(120, 215);
            this.lblReaderAddressValue.Name = "lblReaderAddressValue";
            this.lblReaderAddressValue.Size = new System.Drawing.Size(69, 20);
            this.lblReaderAddressValue.TabIndex = 13;
            this.lblReaderAddressValue.Text = "Address: ";
            // 
            // pbBookCover
            // 
            this.pbBookCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pbBookCover.Location = new System.Drawing.Point(30, 325);
            this.pbBookCover.Name = "pbBookCover";
            this.pbBookCover.Size = new System.Drawing.Size(75, 100);
            this.pbBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBookCover.TabIndex = 14;
            this.pbBookCover.TabStop = false;
            // 
            // lblBookAuthorValue
            // 
            this.lblBookAuthorValue.AutoSize = true;
            this.lblBookAuthorValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBookAuthorValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblBookAuthorValue.Location = new System.Drawing.Point(120, 325);
            this.lblBookAuthorValue.Name = "lblBookAuthorValue";
            this.lblBookAuthorValue.Size = new System.Drawing.Size(113, 21);
            this.lblBookAuthorValue.TabIndex = 15;
            this.lblBookAuthorValue.Text = "Author Name";
            // 
            // lblReturnStatus
            // 
            this.lblReturnStatus.AutoSize = true;
            this.lblReturnStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReturnStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblReturnStatus.Location = new System.Drawing.Point(120, 350);
            this.lblReturnStatus.Name = "lblReturnStatus";
            this.lblReturnStatus.Size = new System.Drawing.Size(52, 20);
            this.lblReturnStatus.TabIndex = 16;
            this.lblReturnStatus.Text = "Status:";
            // 
            // lblReturnStatusValue
            // 
            this.lblReturnStatusValue.AutoSize = true;
            this.lblReturnStatusValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReturnStatusValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblReturnStatusValue.Location = new System.Drawing.Point(185, 349);
            this.lblReturnStatusValue.Name = "lblReturnStatusValue";
            this.lblReturnStatusValue.Size = new System.Drawing.Size(0, 21);
            this.lblReturnStatusValue.TabIndex = 17;
            // 
            // lblIntegrityInput
            // 
            this.lblIntegrityInput.AutoSize = true;
            this.lblIntegrityInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIntegrityInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblIntegrityInput.Location = new System.Drawing.Point(120, 377);
            this.lblIntegrityInput.Name = "lblIntegrityInput";
            this.lblIntegrityInput.Size = new System.Drawing.Size(71, 20);
            this.lblIntegrityInput.TabIndex = 18;
            this.lblIntegrityInput.Text = "Integrity: ";
            // 
            // nudIntegrity
            // 
            this.nudIntegrity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudIntegrity.Location = new System.Drawing.Point(220, 374);
            this.nudIntegrity.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudIntegrity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIntegrity.Name = "nudIntegrity";
            this.nudIntegrity.Size = new System.Drawing.Size(51, 30);
            this.nudIntegrity.TabIndex = 19;
            this.nudIntegrity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(142, 512);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(300, 42);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Return Book";
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
            this.btnCancel.Location = new System.Drawing.Point(142, 567);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(300, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReturnBookform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(640, 700);
            this.Controls.Add(this.pnlReturnCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnBookform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Book";
            this.pnlReturnCard.ResumeLayout(false);
            this.pnlReturnCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReaderAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReturnCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReaderId;
        private System.Windows.Forms.ComboBox cmbReader;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        
        private System.Windows.Forms.PictureBox pbReaderAvatar;
        private System.Windows.Forms.Label lblReaderNameValue;
        private System.Windows.Forms.Label lblReaderPhoneValue;
        private System.Windows.Forms.Label lblReaderAddressValue;
        private System.Windows.Forms.PictureBox pbBookCover;
        private System.Windows.Forms.Label lblBookAuthorValue;
        private System.Windows.Forms.Label lblReturnStatus;
        private System.Windows.Forms.Label lblReturnStatusValue;
        private System.Windows.Forms.Label lblIntegrityInput;
        private System.Windows.Forms.NumericUpDown nudIntegrity;
    }
}