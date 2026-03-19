using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.Forms
{
    public partial class ucReaderCard : UserControl
    {
        private ReaderService _service;
        private Reader _reader;

        public event EventHandler DataChanged;

        private static readonly Color ClrBlue = Color.FromArgb(28, 98, 190);
        private static readonly Color ClrRed = Color.FromArgb(192, 0, 0);
        private static readonly Color ClrBorder = Color.FromArgb(200, 205, 220);

        public ucReaderCard(ReaderService service)
        {
            InitializeComponent();
            _service = service;
            StyleButtons();
        }

        private void StyleButtons()
        {
            EditBttn.FlatStyle = FlatStyle.Flat;
            EditBttn.FlatAppearance.BorderSize = 0;
            EditBttn.BackColor = ClrBlue;
            EditBttn.ForeColor = Color.White;
            EditBttn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            EditBttn.Cursor = Cursors.Hand;
            EditBttn.Text = "Edit";

            DeleteBttn.FlatStyle = FlatStyle.Flat;
            DeleteBttn.FlatAppearance.BorderSize = 0;
            DeleteBttn.BackColor = ClrRed;
            DeleteBttn.ForeColor = Color.White;
            DeleteBttn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            DeleteBttn.Cursor = Cursors.Hand;
            DeleteBttn.Text = "Delete";
        }

        public void SetData(Reader reader)
        {
            _reader = reader;

            lblValueID.Text = reader.Id.ToString();
            string fullName = reader.Name ?? "";
            lblvalueName.Text = fullName.Length > 18 ? fullName.Substring(0, 16) + "…" : fullName;
            lblvalueName.MaximumSize = new Size(160, 20);
            lblvalueName.AutoEllipsis = true;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(lblvalueName, fullName);

            lblValueEmail.Text = reader.Email ?? "—";
            label2.Text = reader.Phone ?? "—";
            lblValueAddress.Text = reader.Address ?? "—";
            lblValueJDate.Text = reader.DateCreate.ToString("dd/MM/yyyy");
            lblValueEDate.Text = reader.DateExpire.HasValue
                                    ? reader.DateExpire.Value.ToString("dd/MM/yyyy")
                                    : "No expiry";
            lblValueIntegrity.Text = reader.Integrity + "/5";

            // Avatar
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.BackColor = Color.FromArgb(218, 222, 236);
            if (!string.IsNullOrEmpty(reader.ImagePath))
            {
                try { picAvatar.Image = Image.FromFile(reader.ImagePath); }
                catch { picAvatar.Image = null; DrawNoImage(); }
            }
            else
            {
                picAvatar.Image = null;
                DrawNoImage();
            }

            BackColor = Color.White;
        }

        private void DrawNoImage()
        {
            int w = picAvatar.Width > 0 ? picAvatar.Width : 170;
            int h = picAvatar.Height > 0 ? picAvatar.Height : 335;
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(218, 222, 236));
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Font f = new Font("Segoe UI", 12f, FontStyle.Bold))
                using (SolidBrush br = new SolidBrush(Color.FromArgb(140, 150, 175)))
                {
                    g.TranslateTransform(w / 2f, h / 2f);
                    g.RotateTransform(-45);
                    SizeF sz = g.MeasureString("No Image", f);
                    g.DrawString("No Image", f, br, -sz.Width / 2f, -sz.Height / 2f);
                    g.ResetTransform();
                }
            }
            picAvatar.Image = bmp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(ClrBorder, 1))
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

        private void DeleteBttn_Click(object sender, EventArgs e)
        {
            if (_reader == null) return;
            if (MessageBox.Show("Delete reader \"" + _reader.Name + "\"?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            var result = _service.Delete(_reader.Id);
            if (result.ok)
            {
                MessageBox.Show("Reader deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
            else
                MessageBox.Show(result.error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EditBttn_Click(object sender, EventArgs e)
        {
            if (_reader == null) return;
            ReaderDetailForm frm = new ReaderDetailForm(_service, _reader);
            if (frm.ShowDialog() == DialogResult.OK)
                DataChanged?.Invoke(this, EventArgs.Empty);
            frm.Dispose();
        }

        private void ucReaderCard_Load(object sender, EventArgs e)
        {
            lblSex.Visible = false;
            lblValueSex.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void lblEmail_Click(object sender, EventArgs e) { }
        private void lblPhone_Click(object sender, EventArgs e) { }
        private void lblAddress_Click(object sender, EventArgs e) { }
        private void iconButton2_Click(object sender, EventArgs e) { }
        private void True(object sender, EventArgs e) { }
    }
}