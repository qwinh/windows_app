namespace LibraryManagement
{
    partial class CrudBookForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.divider = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.lblDatePublish = new System.Windows.Forms.Label();
            this.dtpDatePublish = new System.Windows.Forms.DateTimePicker();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.dgvCopies = new System.Windows.Forms.DataGridView();
            this.btnAddCopy = new System.Windows.Forms.Button();
            this.btnUpdateCopy = new System.Windows.Forms.Button();
            this.btnDeleteCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(98)))), ((int)(((byte)(190)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Books";
            // 
            // pnlList
            // 
            this.pnlList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.pnlList.Controls.Add(this.txtSearch);
            this.pnlList.Controls.Add(this.btnSearch);
            this.pnlList.Controls.Add(this.btnAdd);
            this.pnlList.Controls.Add(this.dataGridViewBooks);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 60);
            this.pnlList.Name = "pnlList";
            this.pnlList.Padding = new System.Windows.Forms.Padding(20);
            this.pnlList.Size = new System.Drawing.Size(500, 690);
            this.pnlList.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 34);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(290, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 34);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(380, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+ New";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AllowUserToAddRows = false;
            this.dataGridViewBooks.AllowUserToDeleteRows = false;
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBooks.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(20, 70);
            this.dataGridViewBooks.MultiSelect = false;
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.RowHeadersVisible = false;
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.RowTemplate.Height = 35;
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(460, 600);
            this.dataGridViewBooks.TabIndex = 3;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Controls.Add(this.lblDetailsTitle);
            this.pnlDetails.Controls.Add(this.btnDelete);
            this.pnlDetails.Controls.Add(this.divider);
            this.pnlDetails.Controls.Add(this.lblName);
            this.pnlDetails.Controls.Add(this.txtName);
            this.pnlDetails.Controls.Add(this.lblAuthor);
            this.pnlDetails.Controls.Add(this.cmbAuthor);
            this.pnlDetails.Controls.Add(this.lblGenre);
            this.pnlDetails.Controls.Add(this.cmbGenre);
            this.pnlDetails.Controls.Add(this.lblDatePublish);
            this.pnlDetails.Controls.Add(this.dtpDatePublish);
            this.pnlDetails.Controls.Add(this.lblImagePath);
            this.pnlDetails.Controls.Add(this.txtImagePath);
            this.pnlDetails.Controls.Add(this.btnBrowse);
            this.pnlDetails.Controls.Add(this.pbCover);
            this.pnlDetails.Controls.Add(this.dgvCopies);
            this.pnlDetails.Controls.Add(this.btnAddCopy);
            this.pnlDetails.Controls.Add(this.btnUpdateCopy);
            this.pnlDetails.Controls.Add(this.btnDeleteCopy);
            this.pnlDetails.Controls.Add(this.btnSave);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(500, 60);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(30);
            this.pnlDetails.Size = new System.Drawing.Size(500, 690);
            this.pnlDetails.TabIndex = 2;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(98)))), ((int)(((byte)(190)))));
            this.lblDetailsTitle.Location = new System.Drawing.Point(25, 20);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(132, 28);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Book Details";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(368, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 36);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // divider
            // 
            this.divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider.Location = new System.Drawing.Point(30, 60);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(440, 2);
            this.divider.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblName.Location = new System.Drawing.Point(30, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Title (*):";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(160, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(310, 30);
            this.txtName.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAuthor.Location = new System.Drawing.Point(30, 120);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(120, 25);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Author (*):";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAuthor.Location = new System.Drawing.Point(160, 118);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(310, 31);
            this.cmbAuthor.TabIndex = 5;
            // 
            // lblGenre
            // 
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGenre.Location = new System.Drawing.Point(30, 160);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(120, 25);
            this.lblGenre.TabIndex = 6;
            this.lblGenre.Text = "Genre (*):";
            this.lblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGenre
            // 
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGenre.Location = new System.Drawing.Point(160, 158);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(310, 31);
            this.cmbGenre.TabIndex = 7;
            // 
            // lblDatePublish
            // 
            this.lblDatePublish.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDatePublish.Location = new System.Drawing.Point(30, 200);
            this.lblDatePublish.Name = "lblDatePublish";
            this.lblDatePublish.Size = new System.Drawing.Size(120, 25);
            this.lblDatePublish.TabIndex = 8;
            this.lblDatePublish.Text = "Publish Date:";
            this.lblDatePublish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDatePublish
            // 
            this.dtpDatePublish.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDatePublish.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePublish.Location = new System.Drawing.Point(160, 198);
            this.dtpDatePublish.Name = "dtpDatePublish";
            this.dtpDatePublish.Size = new System.Drawing.Size(150, 30);
            this.dtpDatePublish.TabIndex = 9;
            // 
            // lblImagePath
            // 
            this.lblImagePath.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblImagePath.Location = new System.Drawing.Point(30, 240);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(120, 25);
            this.lblImagePath.TabIndex = 10;
            this.lblImagePath.Text = "Cover Image:";
            this.lblImagePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImagePath
            // 
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImagePath.Location = new System.Drawing.Point(160, 238);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(230, 30);
            this.txtImagePath.TabIndex = 11;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(98)))), ((int)(((byte)(190)))));
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(400, 238);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(70, 30);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            // 
            // pbCover
            // 
            this.pbCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.pbCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCover.Location = new System.Drawing.Point(160, 280);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(100, 130);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCover.TabIndex = 13;
            this.pbCover.TabStop = false;
            // 
            // dgvCopies
            // 
            this.dgvCopies.AllowUserToAddRows = false;
            this.dgvCopies.AllowUserToDeleteRows = false;
            this.dgvCopies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCopies.BackgroundColor = System.Drawing.Color.White;
            this.dgvCopies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCopies.Location = new System.Drawing.Point(160, 430);
            this.dgvCopies.MultiSelect = false;
            this.dgvCopies.Name = "dgvCopies";
            this.dgvCopies.ReadOnly = true;
            this.dgvCopies.RowHeadersVisible = false;
            this.dgvCopies.RowHeadersWidth = 51;
            this.dgvCopies.RowTemplate.Height = 30;
            this.dgvCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCopies.Size = new System.Drawing.Size(310, 150);
            this.dgvCopies.TabIndex = 14;
            // 
            // btnAddCopy
            // 
            this.btnAddCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(98)))), ((int)(((byte)(190)))));
            this.btnAddCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCopy.FlatAppearance.BorderSize = 0;
            this.btnAddCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddCopy.ForeColor = System.Drawing.Color.White;
            this.btnAddCopy.Location = new System.Drawing.Point(30, 430);
            this.btnAddCopy.Name = "btnAddCopy";
            this.btnAddCopy.Size = new System.Drawing.Size(120, 30);
            this.btnAddCopy.TabIndex = 15;
            this.btnAddCopy.Text = "Add Copy";
            this.btnAddCopy.UseVisualStyleBackColor = false;
            // 
            // btnUpdateCopy
            // 
            this.btnUpdateCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnUpdateCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateCopy.FlatAppearance.BorderSize = 0;
            this.btnUpdateCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateCopy.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateCopy.Location = new System.Drawing.Point(30, 470);
            this.btnUpdateCopy.Name = "btnUpdateCopy";
            this.btnUpdateCopy.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateCopy.TabIndex = 16;
            this.btnUpdateCopy.Text = "Edit Copy";
            this.btnUpdateCopy.UseVisualStyleBackColor = false;
            // 
            // btnDeleteCopy
            // 
            this.btnDeleteCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCopy.FlatAppearance.BorderSize = 0;
            this.btnDeleteCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCopy.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCopy.Location = new System.Drawing.Point(30, 510);
            this.btnDeleteCopy.Name = "btnDeleteCopy";
            this.btnDeleteCopy.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteCopy.TabIndex = 17;
            this.btnDeleteCopy.Text = "Delete Copy";
            this.btnDeleteCopy.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(160, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(310, 40);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save Book";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // CrudBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CrudBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Books";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label divider;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ComboBox cmbAuthor;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.Label lblDatePublish;
        private System.Windows.Forms.DateTimePicker dtpDatePublish;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.DataGridView dgvCopies;
        private System.Windows.Forms.Button btnAddCopy;
        private System.Windows.Forms.Button btnUpdateCopy;
        private System.Windows.Forms.Button btnDeleteCopy;
        private System.Windows.Forms.Button btnSave;
    }
}