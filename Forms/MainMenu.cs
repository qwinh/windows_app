using System;
using System.Windows.Forms;
using LibraryManagement.Helpers;

namespace LibraryManagement
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        // button1 → Login/Register Or Logout
        private void btnLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn)
            {
                // Action: Logout
                SessionManager.Logout();
                MessageBox.Show("You have been logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshLoginState();
                return;
            }

            // Action: Login
            this.Hide();
            var loginForm = new LoginRegisterForm();
            loginForm.FormClosed += (_, __) =>
            {
                this.Show();
                RefreshLoginState();
            };
            loginForm.ShowDialog(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshLoginState();
        }

        private void RefreshLoginState()
        {
            if (SessionManager.IsLoggedIn)
            {
                btnLoginRegister.Text = $"Logout ({SessionManager.CurrentEmployee.Name})";
            }
            else
            {
                btnLoginRegister.Text = "Login / Register";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Always release the login lock when leaving the main menu.
            if (SessionManager.IsLoggedIn)
            {
                SessionManager.Logout();
            }
        }

        // button3 → Manage Books (CRUD)
        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            CrudBookForm crudBookForm = new CrudBookForm();
            crudBookForm.ShowDialog();
        }

        // button4 → Manage Readers (CRUD)
        private void btnManageReaders_Click(object sender, EventArgs e)
        {
            CrudReaderForm crudReaderForm = new CrudReaderForm();
            crudReaderForm.ShowDialog();
        }

        // button5 → Borrow Book
        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            BorrowBookform borrowForm = new BorrowBookform();
            borrowForm.ShowDialog();
        }

        // button6 → Return Book
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
