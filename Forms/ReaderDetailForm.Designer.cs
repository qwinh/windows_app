namespace LibraryManagement.Forms
{
    partial class ReaderDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.divider = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.dtpExpire = new System.Windows.Forms.DateTimePicker();
            this.chkNoExpiry = new System.Windows.Forms.CheckBox();
            this.lblIntegrity = new System.Windows.Forms.Label();
            this.nudIntegrity = new System.Windows.Forms.NumericUpDown();
            this.lblIntHint = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrity)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(28, 98, 190);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(490, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Reader";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.btnSave);
            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.lblIntHint);
            this.pnlBody.Controls.Add(this.nudIntegrity);
            this.pnlBody.Controls.Add(this.lblIntegrity);
            this.pnlBody.Controls.Add(this.chkNoExpiry);
            this.pnlBody.Controls.Add(this.dtpExpire);
            this.pnlBody.Controls.Add(this.lblExpiry);
            this.pnlBody.Controls.Add(this.divider);
            this.pnlBody.Controls.Add(this.btnBrowse);
            this.pnlBody.Controls.Add(this.txtImagePath);
            this.pnlBody.Controls.Add(this.lblImagePath);
            this.pnlBody.Controls.Add(this.txtAddress);
            this.pnlBody.Controls.Add(this.lblAddress);
            this.pnlBody.Controls.Add(this.txtPhone);
            this.pnlBody.Controls.Add(this.lblPhone);
            this.pnlBody.Controls.Add(this.txtEmail);
            this.pnlBody.Controls.Add(this.lblEmail);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.lblName);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 50);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.pnlBody.Size = new System.Drawing.Size(490, 348);
            this.pnlBody.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblName.Location = new System.Drawing.Point(0, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name (*):";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(142, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(285, 26);
            this.txtName.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmail.Location = new System.Drawing.Point(0, 56);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(120, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(142, 52);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 26);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhone.Location = new System.Drawing.Point(0, 92);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(120, 20);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(142, 88);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(170, 26);
            this.txtPhone.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAddress.Location = new System.Drawing.Point(0, 128);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(120, 20);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(142, 124);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(285, 26);
            this.txtAddress.TabIndex = 7;
            // 
            // lblImagePath
            // 
            this.lblImagePath.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblImagePath.Location = new System.Drawing.Point(0, 164);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(120, 20);
            this.lblImagePath.TabIndex = 8;
            this.lblImagePath.Text = "Image Path:";
            this.lblImagePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImagePath
            // 
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImagePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImagePath.Location = new System.Drawing.Point(142, 160);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(220, 26);
            this.txtImagePath.TabIndex = 9;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Text = "...";
            this.btnBrowse.Location = new System.Drawing.Point(370, 160);
            this.btnBrowse.Size = new System.Drawing.Size(60, 26);
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 98, 190);
            this.btnBrowse.FlatAppearance.BorderSize = 1;
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(28, 98, 190);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // divider
            // 
            this.divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider.Location = new System.Drawing.Point(0, 196);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(450, 2);
            this.divider.TabIndex = 10;
            // 
            // lblExpiry
            // 
            this.lblExpiry.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblExpiry.Location = new System.Drawing.Point(0, 210);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(120, 20);
            this.lblExpiry.TabIndex = 11;
            this.lblExpiry.Text = "Expiry Date:";
            this.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpExpire
            // 
            this.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpire.Location = new System.Drawing.Point(142, 206);
            this.dtpExpire.Name = "dtpExpire";
            this.dtpExpire.Size = new System.Drawing.Size(155, 26);
            this.dtpExpire.TabIndex = 12;
            this.dtpExpire.Value = new System.DateTime(2027, 3, 20, 0, 0, 0, 0);
            // 
            // chkNoExpiry
            // 
            this.chkNoExpiry.AutoSize = true;
            this.chkNoExpiry.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkNoExpiry.Location = new System.Drawing.Point(307, 210);
            this.chkNoExpiry.Name = "chkNoExpiry";
            this.chkNoExpiry.Size = new System.Drawing.Size(90, 22);
            this.chkNoExpiry.TabIndex = 13;
            this.chkNoExpiry.Text = "No expiry";
            this.chkNoExpiry.CheckedChanged += new System.EventHandler(this.chkNoExpiry_CheckedChanged);
            // 
            // lblIntegrity
            // 
            this.lblIntegrity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblIntegrity.Location = new System.Drawing.Point(0, 246);
            this.lblIntegrity.Name = "lblIntegrity";
            this.lblIntegrity.Size = new System.Drawing.Size(120, 20);
            this.lblIntegrity.TabIndex = 14;
            this.lblIntegrity.Text = "Integrity (1-5):";
            this.lblIntegrity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudIntegrity
            // 
            this.nudIntegrity.Location = new System.Drawing.Point(142, 242);
            this.nudIntegrity.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.nudIntegrity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudIntegrity.Name = "nudIntegrity";
            this.nudIntegrity.Size = new System.Drawing.Size(60, 26);
            this.nudIntegrity.TabIndex = 15;
            this.nudIntegrity.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblIntHint
            // 
            this.lblIntHint.AutoSize = true;
            this.lblIntHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblIntHint.ForeColor = System.Drawing.Color.Gray;
            this.lblIntHint.Location = new System.Drawing.Point(210, 247);
            this.lblIntHint.Name = "lblIntHint";
            this.lblIntHint.Size = new System.Drawing.Size(70, 18);
            this.lblIntHint.TabIndex = 16;
            this.lblIntHint.Text = "5 = perfect";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 40, 80);
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(28, 40, 80);
            this.btnCancel.Location = new System.Drawing.Point(142, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 36);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 150, 70);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ReaderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 398);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReaderDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reader";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrity)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader, pnlBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName, lblEmail, lblPhone, lblAddress, lblImagePath;
        private System.Windows.Forms.Label lblExpiry, lblIntegrity, lblIntHint, divider;
        private System.Windows.Forms.TextBox txtName, txtEmail, txtPhone, txtAddress, txtImagePath;
        private System.Windows.Forms.DateTimePicker dtpExpire;
        private System.Windows.Forms.CheckBox chkNoExpiry;
        private System.Windows.Forms.NumericUpDown nudIntegrity;
        private System.Windows.Forms.Button btnCancel, btnSave, btnBrowse;
    }
}