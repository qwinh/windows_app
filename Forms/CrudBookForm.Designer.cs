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
            this.components = new System.ComponentModel.Container();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEditFields = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPublish = new System.Windows.Forms.Label();
            this.dtpPublish = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCopiesTitle = new System.Windows.Forms.Label();
            this.lblIntegrity = new System.Windows.Forms.Label();
            this.nudIntegrity = new System.Windows.Forms.NumericUpDown();
            this.btnAddCopy = new System.Windows.Forms.Button();
            this.btnDeleteCopy = new System.Windows.Forms.Button();
            this.dgvCopies = new System.Windows.Forms.DataGridView();
            this.colCopyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopyTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntegrity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAuthors = new System.Windows.Forms.Label();
            this.clbAuthors = new System.Windows.Forms.CheckedListBox();
            this.lblGenres = new System.Windows.Forms.Label();
            this.clbGenres = new System.Windows.Forms.CheckedListBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.pnlCard.SuspendLayout();
            this.pnlEditFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.txtSearch);
            this.pnlCard.Controls.Add(this.btnSearch);
            this.pnlCard.Controls.Add(this.lblCount);
            this.pnlCard.Controls.Add(this.btnAdd);
            this.pnlCard.Controls.Add(this.btnEdit);
            this.pnlCard.Controls.Add(this.btnDelete);
            this.pnlCard.Controls.Add(this.btnClose);
            this.pnlCard.Controls.Add(this.dgvBooks);
            this.pnlCard.Controls.Add(this.pnlEditFields);
            this.pnlCard.Controls.Add(this.lblCopiesTitle);
            this.pnlCard.Controls.Add(this.lblIntegrity);
            this.pnlCard.Controls.Add(this.nudIntegrity);
            this.pnlCard.Controls.Add(this.btnAddCopy);
            this.pnlCard.Controls.Add(this.btnDeleteCopy);
            this.pnlCard.Controls.Add(this.dgvCopies);
            this.pnlCard.Location = new System.Drawing.Point(20, 20);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(960, 700);
            this.pnlCard.TabIndex = 0;
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Book Management";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 65);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(500, 22);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Add, edit or remove book titles and physical copies";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(30, 102);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(340, 30);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(380, 101);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblCount.Location = new System.Drawing.Point(490, 106);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(150, 22);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "0 record(s)";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(30, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "+ Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(130, 145);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 34);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(230, 145);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(860, 145);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 34);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBooks.ColumnHeadersHeight = 36;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colDate,
            this.colCopies});
            this.dgvBooks.EnableHeadersVisualStyles = false;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvBooks.Location = new System.Drawing.Point(30, 190);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.RowTemplate.Height = 32;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(900, 220);
            this.dgvBooks.TabIndex = 9;
            this.dgvBooks.SelectionChanged += new System.EventHandler(this.dgvBooks_SelectionChanged);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colName
            // 
            this.colName.HeaderText = "Title";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 500;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Published";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;
            // 
            // colCopies
            // 
            this.colCopies.HeaderText = "Copies";
            this.colCopies.Name = "colCopies";
            this.colCopies.ReadOnly = true;
            this.colCopies.Width = 80;
            // 
            // pnlEditFields
            // 
            this.pnlEditFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlEditFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditFields.Controls.Add(this.lblName);
            this.pnlEditFields.Controls.Add(this.txtName);
            this.pnlEditFields.Controls.Add(this.lblPublish);
            this.pnlEditFields.Controls.Add(this.dtpPublish);
            this.pnlEditFields.Controls.Add(this.btnSave);
            this.pnlEditFields.Controls.Add(this.btnCancel);
            this.pnlEditFields.Controls.Add(this.lblAuthors);
            this.pnlEditFields.Controls.Add(this.clbAuthors);
            this.pnlEditFields.Controls.Add(this.lblGenres);
            this.pnlEditFields.Controls.Add(this.clbGenres);
            this.pnlEditFields.Controls.Add(this.lblImage);
            this.pnlEditFields.Controls.Add(this.pbImage);
            this.pnlEditFields.Controls.Add(this.btnImage);
            this.pnlEditFields.Controls.Add(this.btnClearImage);
            this.pnlEditFields.Location = new System.Drawing.Point(30, 190);
            this.pnlEditFields.Name = "pnlEditFields";
            this.pnlEditFields.Size = new System.Drawing.Size(900, 220);
            this.pnlEditFields.TabIndex = 10;
            this.pnlEditFields.Visible = false;

            // lblAuthors
            this.lblAuthors.AutoSize = true;
            this.lblAuthors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAuthors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblAuthors.Location = new System.Drawing.Point(14, 75);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(65, 20);
            this.lblAuthors.Text = "Authors";
            // clbAuthors
            this.clbAuthors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbAuthors.FormattingEnabled = true;
            this.clbAuthors.Location = new System.Drawing.Point(14, 95);
            this.clbAuthors.Name = "clbAuthors";
            this.clbAuthors.Size = new System.Drawing.Size(220, 114);
            // lblGenres
            this.lblGenres.AutoSize = true;
            this.lblGenres.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGenres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblGenres.Location = new System.Drawing.Point(250, 75);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(58, 20);
            this.lblGenres.Text = "Genres";
            // clbGenres
            this.clbGenres.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbGenres.FormattingEnabled = true;
            this.clbGenres.Location = new System.Drawing.Point(250, 95);
            this.clbGenres.Name = "clbGenres";
            this.clbGenres.Size = new System.Drawing.Size(220, 114);
            // lblImage
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblImage.Location = new System.Drawing.Point(490, 75);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(95, 20);
            this.lblImage.Text = "Cover Image";
            // pbImage
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(490, 95);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(80, 114);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // btnImage
            this.btnImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImage.FlatAppearance.BorderSize = 0;
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImage.ForeColor = System.Drawing.Color.White;
            this.btnImage.Location = new System.Drawing.Point(580, 95);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(100, 32);
            this.btnImage.Text = "Browse...";
            this.btnImage.UseVisualStyleBackColor = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // btnClearImage
            this.btnClearImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnClearImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearImage.FlatAppearance.BorderSize = 0;
            this.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearImage.ForeColor = System.Drawing.Color.White;
            this.btnClearImage.Location = new System.Drawing.Point(580, 137);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(100, 32);
            this.btnClearImage.Text = "Clear";
            this.btnClearImage.UseVisualStyleBackColor = false;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblName.Location = new System.Drawing.Point(14, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Title *";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(14, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(480, 30);
            this.txtName.TabIndex = 1;
            // 
            // lblPublish
            // 
            this.lblPublish.AutoSize = true;
            this.lblPublish.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPublish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblPublish.Location = new System.Drawing.Point(510, 12);
            this.lblPublish.Name = "lblPublish";
            this.lblPublish.Size = new System.Drawing.Size(160, 20);
            this.lblPublish.TabIndex = 2;
            this.lblPublish.Text = "Publish Date (optional)";
            // 
            // dtpPublish
            // 
            this.dtpPublish.Checked = false;
            this.dtpPublish.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpPublish.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPublish.Location = new System.Drawing.Point(510, 34);
            this.dtpPublish.Name = "dtpPublish";
            this.dtpPublish.ShowCheckBox = true;
            this.dtpPublish.Size = new System.Drawing.Size(200, 30);
            this.dtpPublish.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(722, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.btnCancel.Location = new System.Drawing.Point(810, 34);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCopiesTitle
            // 
            this.lblCopiesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCopiesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(43)))), ((int)(((byte)(75)))));
            this.lblCopiesTitle.Location = new System.Drawing.Point(30, 424);
            this.lblCopiesTitle.Name = "lblCopiesTitle";
            this.lblCopiesTitle.Size = new System.Drawing.Size(300, 26);
            this.lblCopiesTitle.TabIndex = 11;
            this.lblCopiesTitle.Text = "Physical Copies";
            // 
            // lblIntegrity
            // 
            this.lblIntegrity.AutoSize = true;
            this.lblIntegrity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIntegrity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblIntegrity.Location = new System.Drawing.Point(620, 428);
            this.lblIntegrity.Name = "lblIntegrity";
            this.lblIntegrity.Size = new System.Drawing.Size(60, 20);
            this.lblIntegrity.TabIndex = 12;
            this.lblIntegrity.Text = "Integrity";
            // 
            // nudIntegrity
            // 
            this.nudIntegrity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudIntegrity.Location = new System.Drawing.Point(690, 425);
            this.nudIntegrity.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudIntegrity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudIntegrity.Name = "nudIntegrity";
            this.nudIntegrity.Size = new System.Drawing.Size(50, 26);
            this.nudIntegrity.TabIndex = 13;
            this.nudIntegrity.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnAddCopy
            // 
            this.btnAddCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnAddCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCopy.Enabled = false;
            this.btnAddCopy.FlatAppearance.BorderSize = 0;
            this.btnAddCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddCopy.ForeColor = System.Drawing.Color.White;
            this.btnAddCopy.Location = new System.Drawing.Point(750, 422);
            this.btnAddCopy.Name = "btnAddCopy";
            this.btnAddCopy.Size = new System.Drawing.Size(90, 30);
            this.btnAddCopy.TabIndex = 14;
            this.btnAddCopy.Text = "+ Add Copy";
            this.btnAddCopy.UseVisualStyleBackColor = false;
            this.btnAddCopy.Click += new System.EventHandler(this.btnAddCopy_Click);
            // 
            // btnDeleteCopy
            // 
            this.btnDeleteCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDeleteCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCopy.FlatAppearance.BorderSize = 0;
            this.btnDeleteCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCopy.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCopy.Location = new System.Drawing.Point(850, 422);
            this.btnDeleteCopy.Name = "btnDeleteCopy";
            this.btnDeleteCopy.Size = new System.Drawing.Size(90, 30);
            this.btnDeleteCopy.TabIndex = 15;
            this.btnDeleteCopy.Text = "Del Copy";
            this.btnDeleteCopy.UseVisualStyleBackColor = false;
            this.btnDeleteCopy.Click += new System.EventHandler(this.btnDeleteCopy_Click);
            // 
            // dgvCopies
            // 
            this.dgvCopies.AllowUserToAddRows = false;
            this.dgvCopies.AllowUserToDeleteRows = false;
            this.dgvCopies.BackgroundColor = System.Drawing.Color.White;
            this.dgvCopies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCopies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCopies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCopies.ColumnHeadersHeight = 36;
            this.dgvCopies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCopies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCopyId,
            this.colCopyTitle,
            this.colIntegrity,
            this.colAdded,
            this.colStatus});
            this.dgvCopies.EnableHeadersVisualStyles = false;
            this.dgvCopies.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvCopies.Location = new System.Drawing.Point(30, 460);
            this.dgvCopies.MultiSelect = false;
            this.dgvCopies.Name = "dgvCopies";
            this.dgvCopies.ReadOnly = true;
            this.dgvCopies.RowHeadersVisible = false;
            this.dgvCopies.RowTemplate.Height = 32;
            this.dgvCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCopies.Size = new System.Drawing.Size(900, 200);
            this.dgvCopies.TabIndex = 16;
            // 
            // colCopyId
            // 
            this.colCopyId.HeaderText = "Copy ID";
            this.colCopyId.Name = "colCopyId";
            this.colCopyId.ReadOnly = true;
            this.colCopyId.Width = 70;
            // 
            // colCopyTitle
            // 
            this.colCopyTitle.HeaderText = "Title";
            this.colCopyTitle.Name = "colCopyTitle";
            this.colCopyTitle.ReadOnly = true;
            this.colCopyTitle.Width = 380;
            // 
            // colIntegrity
            // 
            this.colIntegrity.HeaderText = "Integrity";
            this.colIntegrity.Name = "colIntegrity";
            this.colIntegrity.ReadOnly = true;
            this.colIntegrity.Width = 80;
            // 
            // colAdded
            // 
            this.colAdded.HeaderText = "Date Added";
            this.colAdded.Name = "colAdded";
            this.colAdded.ReadOnly = true;
            this.colAdded.Width = 110;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 100;
            // 
            // CrudBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1000, 740);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrudBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Management";
            this.pnlEditFields.ResumeLayout(false);
            this.pnlEditFields.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopies;
        private System.Windows.Forms.Panel pnlEditFields;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPublish;
        private System.Windows.Forms.DateTimePicker dtpPublish;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCopiesTitle;
        private System.Windows.Forms.Label lblIntegrity;
        private System.Windows.Forms.NumericUpDown nudIntegrity;
        private System.Windows.Forms.Button btnAddCopy;
        private System.Windows.Forms.Button btnDeleteCopy;
        private System.Windows.Forms.DataGridView dgvCopies;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopyTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIntegrity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdded;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label lblAuthors;
        private System.Windows.Forms.CheckedListBox clbAuthors;
        private System.Windows.Forms.Label lblGenres;
        private System.Windows.Forms.CheckedListBox clbGenres;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
    }
}