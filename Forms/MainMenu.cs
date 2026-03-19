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
            
            // Attach primary button hover effects
            AttachHoverEffect(btnLoginRegister, System.Drawing.Color.FromArgb(29, 78, 216), System.Drawing.Color.FromArgb(37, 99, 235));
            
            // Attach card hover effects (slightly deeper white/gray on hover)
            AttachHoverEffect(btnManageBooks, System.Drawing.Color.FromArgb(240, 245, 250), System.Drawing.Color.White);
            AttachHoverEffect(btnManageReaders, System.Drawing.Color.FromArgb(240, 245, 250), System.Drawing.Color.White);
            AttachHoverEffect(btnBorrowBook, System.Drawing.Color.FromArgb(240, 245, 250), System.Drawing.Color.White);
            AttachHoverEffect(btnReturnBook, System.Drawing.Color.FromArgb(240, 245, 250), System.Drawing.Color.White);
            
            // Attach secondary/exit hover effect
            AttachHoverEffect(btnExit, System.Drawing.Color.FromArgb(220, 225, 235), System.Drawing.Color.FromArgb(240, 242, 245));

            RefreshLoginState();
        }

        private static void AttachHoverEffect(Button btn, System.Drawing.Color hoverColor, System.Drawing.Color normalColor)
        {
            btn.MouseEnter += (_, __) => btn.BackColor = hoverColor;
            btn.MouseLeave += (_, __) => btn.BackColor = normalColor;
        }

        private void RefreshLoginState()
        {
            if (SessionManager.IsLoggedIn)
            {
                btnLoginRegister.Text = "Logout";
                lblSessionStatus.Text = $"Signed in as: {SessionManager.CurrentEmployee.Name}";
                lblSessionStatus.ForeColor = System.Drawing.Color.FromArgb(22, 43, 75); // Darker when active
                btnProfile.Visible = true;
            }
            else
            {
                btnLoginRegister.Text = "Login / Register";
                lblSessionStatus.Text = "Not signed in";
                lblSessionStatus.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); // Muted when inactive
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
            ReaderService service = new ReaderService();
            CrudReaderForm crudReaderForm = new CrudReaderForm(service);
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
