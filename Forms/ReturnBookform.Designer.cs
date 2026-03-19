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
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblReaderId = new System.Windows.Forms.Label();
            this.cmbReader = new System.Windows.Forms.ComboBox();
            this.lblBookId = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlReturnCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReturnCard
            // 
            this.pnlReturnCard.BackColor = System.Drawing.Color.White;
            this.pnlReturnCard.Controls.Add(this.lblTitle);
            this.pnlReturnCard.Controls.Add(this.lblSubtitle);
            this.pnlReturnCard.Controls.Add(this.lblReaderId);
            this.pnlReturnCard.Controls.Add(this.cmbReader);
            this.pnlReturnCard.Controls.Add(this.lblBookId);
            this.pnlReturnCard.Controls.Add(this.cmbBook);
            this.pnlReturnCard.Controls.Add(this.btnSubmit);
            this.pnlReturnCard.Controls.Add(this.btnCancel);
            this.pnlReturnCard.Location = new System.Drawing.Point(35, 38);
            this.pnlReturnCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlReturnCard.Name = "pnlReturnCard";
            this.pnlReturnCard.Padding = new System.Windows.Forms.Padding(32, 30, 32, 30);
            this.pnlReturnCard.Size = new System.Drawing.Size(655, 575);
            this.pnlReturnCard.TabIndex = 0;
            this.pnlReturnCard.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblTitle.Location = new System.Drawing.Point(34, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(338, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Return Book";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblSubtitle.Location = new System.Drawing.Point(34, 81);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(450, 28);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Search by reader and select borrowed book below";
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
            this.cmbReader.SelectedIndexChanged += new System.EventHandler(this.cmbReader_SelectedIndexChanged);
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblBookId.Location = new System.Drawing.Point(34, 212);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(206, 25);
            this.lblBookId.TabIndex = 4;
            this.lblBookId.Text = "Borrowed Book (Copy)";
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
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(160, 325);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(338, 52);
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
            this.btnCancel.Location = new System.Drawing.Point(160, 399);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(338, 48);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReturnBookform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(720, 650);
            this.Controls.Add(this.pnlReturnCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnBookform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Book";
            this.pnlReturnCard.ResumeLayout(false);
            this.pnlReturnCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReturnCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblReaderId;
        private System.Windows.Forms.ComboBox cmbReader;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}