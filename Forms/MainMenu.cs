using LibraryManagement.BLL;
using LibraryManagement.Forms;
using LibraryManagement.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                // Action: Logout
                SessionManager.Logout();
                MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            RefreshLoginState();
        }

        private void RefreshLoginState()
        {
            if (SessionManager.IsLoggedIn)
            {
                btnLoginRegister.Text = "Logout";
                var emp = SessionManager.CurrentEmployee;
                lblSessionStatus.Text = emp != null ? $"Signed in as: {emp.Name}" : "Signed in";
                lblSessionStatus.ForeColor = System.Drawing.Color.FromArgb(22, 43, 75);
                btnProfile.Visible = true;
            }
            else
            {
                btnLoginRegister.Text = "Login / Register";
                lblSessionStatus.Text = "Not signed in";
                btnProfile.Visible = false;
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            var profileForm = new ProfileForm();
            profileForm.FormClosed += (_, __) =>
            {
                this.Show();
                RefreshLoginState();
            };
            profileForm.ShowDialog(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                SessionManager.Logout();
            }
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            CrudBookForm crudBookForm = new CrudBookForm();
            crudBookForm.ShowDialog();
        }
        private void btnManageReaders_Click(object sender, EventArgs e)
        {
            ReaderService service = new ReaderService();
            CrudReaderForm crudReaderForm = new CrudReaderForm(service);
            crudReaderForm.ShowDialog();
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            BorrowBookform borrowForm = new BorrowBookform();
            borrowForm.ShowDialog();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            ReturnBookform returnForm = new ReturnBookform();
            returnForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}