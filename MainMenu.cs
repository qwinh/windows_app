using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        // button1 → Login
        private void button1_Click(object sender, EventArgs e)
        {
            LoginRegisterForm loginForm = new LoginRegisterForm();
            loginForm.ShowDialog();
        }

        // button2 → Register
        private void button2_Click(object sender, EventArgs e)
        {
            LoginRegisterForm registerForm = new LoginRegisterForm();
            registerForm.ShowDialog();
        }

        // button3 → Manage Books (CRUD)
        private void button3_Click(object sender, EventArgs e)
        {
            CrudBookForm crudBookForm = new CrudBookForm();
            crudBookForm.ShowDialog();
        }

        // button4 → Manage Readers (CRUD)
        private void button4_Click(object sender, EventArgs e)
        {
            CrudReaderForm crudReaderForm = new CrudReaderForm();
            crudReaderForm.ShowDialog();
        }

        // button5 → Borrow Book
        private void button5_Click(object sender, EventArgs e)
        {
            BorrowBookform borrowForm = new BorrowBookform();
            borrowForm.ShowDialog();
        }

        // button6 → Return Book
        private void button6_Click(object sender, EventArgs e)
        {
            ReturnBookform returnForm = new ReturnBookform();
            returnForm.ShowDialog();
        }
    }
}
