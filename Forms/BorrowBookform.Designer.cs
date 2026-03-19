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
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblReaderId = new System.Windows.Forms.Label();
            this.cmbReader = new System.Windows.Forms.ComboBox();
            this.lblBookId = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.lblDateExpire = new System.Windows.Forms.Label();
            this.dtpDateExpire = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBorrowCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorrowCard
            // 
            this.pnlBorrowCard.BackColor = System.Drawing.Color.White;
            this.pnlBorrowCard.Controls.Add(this.lblTitle);
            this.pnlBorrowCard.Controls.Add(this.lblSubtitle);
            this.pnlBorrowCard.Controls.Add(this.lblReaderId);
            this.pnlBorrowCard.Controls.Add(this.cmbReader);
            this.pnlBorrowCard.Controls.Add(this.lblBookId);
            this.pnlBorrowCard.Controls.Add(this.cmbBook);
            this.pnlBorrowCard.Controls.Add(this.lblDateExpire);
            this.pnlBorrowCard.Controls.Add(this.dtpDateExpire);
            this.pnlBorrowCard.Controls.Add(this.btnSubmit);
            this.pnlBorrowCard.Controls.Add(this.btnCancel);
            this.pnlBorrowCard.Location = new System.Drawing.Point(35, 38);
            this.pnlBorrowCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBorrowCard.Name = "pnlBorrowCard";
            this.pnlBorrowCard.Padding = new System.Windows.Forms.Padding(32, 30, 32, 30);
            this.pnlBorrowCard.Size = new System.Drawing.Size(655, 575);
            this.pnlBorrowCard.TabIndex = 0;
            this.pnlBorrowCard.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblTitle.Location = new System.Drawing.Point(34, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(338, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Issue Book";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblSubtitle.Location = new System.Drawing.Point(34, 81);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(338, 28);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Search by reader and book name below";
            // 
            // lblReaderId
            // 
            this.lblReaderId.AutoSize = true;
            this.lblReaderId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReaderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblReaderId.Location = new System.Drawing.Point(34, 131);
            this.lblReaderId.Name = "lblReaderId";
            this.lblReaderId.Size = new System.Drawing.Size(72, 25);
            this.lblReaderId.TabIndex = 2;
            this.lblReaderId.Text = "Reader";
            // 
            // cmbReader
            // 
            this.cmbReader.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReader.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbReader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReader.Location = new System.Drawing.Point(34, 159);
            this.cmbReader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbReader.Name = "cmbReader";
            this.cmbReader.Size = new System.Drawing.Size(586, 36);
            this.cmbReader.TabIndex = 3;
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblBookId.Location = new System.Drawing.Point(34, 212);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(118, 25);
            this.lblBookId.TabIndex = 4;
            this.lblBookId.Text = "Book (Copy)";
            // 
            // cmbBook
            // 
            this.cmbBook.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBook.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBook.Location = new System.Drawing.Point(34, 240);
            this.cmbBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(586, 36);
            this.cmbBook.TabIndex = 5;
            // 
            // lblDateExpire
            // 
            this.lblDateExpire.AutoSize = true;
            this.lblDateExpire.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateExpire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblDateExpire.Location = new System.Drawing.Point(34, 294);
            this.lblDateExpire.Name = "lblDateExpire";
            this.lblDateExpire.Size = new System.Drawing.Size(115, 25);
            this.lblDateExpire.TabIndex = 6;
            this.lblDateExpire.Text = "Return Date";
            // 
            // dtpDateExpire
            // 
            this.dtpDateExpire.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateExpire.Location = new System.Drawing.Point(34, 321);
            this.dtpDateExpire.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDateExpire.Name = "dtpDateExpire";
            this.dtpDateExpire.Size = new System.Drawing.Size(586, 34);
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
            this.btnSubmit.Location = new System.Drawing.Point(160, 411);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(338, 52);
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
            this.btnCancel.Location = new System.Drawing.Point(160, 485);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(338, 48);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BorrowBookform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(720, 650);
            this.Controls.Add(this.pnlBorrowCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorrowBookform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Book";
            this.pnlBorrowCard.ResumeLayout(false);
            this.pnlBorrowCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorrowCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblReaderId;
        private System.Windows.Forms.ComboBox cmbReader;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label lblDateExpire;
        private System.Windows.Forms.DateTimePicker dtpDateExpire;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}