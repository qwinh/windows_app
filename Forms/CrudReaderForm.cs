using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.Forms
{
    public partial class CrudReaderForm : Form
    {
        private readonly ReaderService _service;

        public CrudReaderForm(ReaderService service)
        {
            _service = service;
            InitializeComponent();
            SetSearchHint();
            // Re-layout cards when form is resized so cards always fill width
            panelCards.Resize += (s, e) => RefreshCardWidths();
            LoadCards("");
        }

        private void SetSearchHint()
        {
            txtSearch.Text = "Search by name, email or phone...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.ForeColor == Color.Gray)
                { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; }
            };
            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                { txtSearch.Text = "Search by name, email or phone..."; txtSearch.ForeColor = Color.Gray; }
            };
        }

        private string GetKeyword()
            => txtSearch.ForeColor == Color.Gray ? "" : txtSearch.Text.Trim();

        // Card width = full client width of panelCards minus scrollbar
        private int CardWidth()
            => panelCards.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;

        private void LoadCards(string keyword)
        {
            panelCards.SuspendLayout();
            panelCards.Controls.Clear();

            List<Reader> list = _service.Search(keyword, null);

            int y = 0;
            foreach (Reader r in list)
            {
                ucReaderCard card = new ucReaderCard(_service);
                card.SetData(r);
                card.Location = new Point(0, y);
                card.Width = CardWidth();
                card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                card.DataChanged += (s, e) => LoadCards(GetKeyword());
                panelCards.Controls.Add(card);
                y += card.Height + 6;
            }

            if (list.Count == 0)
            {
                Label lbl = new Label
                {
                    Text = "No readers found.",
                    AutoSize = true,
                    Location = new Point(20, 20),
                    Font = new Font("Segoe UI", 10f),
                    ForeColor = Color.Gray
                };
                panelCards.Controls.Add(lbl);
            }

            panelCards.ResumeLayout();
        }

        // Keep cards full-width when window is resized
        private void RefreshCardWidths()
        {
            int w = CardWidth();
            foreach (Control c in panelCards.Controls)
            {
                if (c is ucReaderCard) c.Width = w;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) => LoadCards(GetKeyword());
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) LoadCards(GetKeyword()); }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ReaderDetailForm frm = new ReaderDetailForm(_service, null);
            if (frm.ShowDialog() == DialogResult.OK) LoadCards(GetKeyword());
            frm.Dispose();
        }

        private void panelCards_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCards_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}