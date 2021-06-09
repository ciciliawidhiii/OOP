using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eRent_Camera
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {

            Login logClass = new Login();

            string username1 = UserTb.Text;
            string password1 = PassTb.Text;

            logClass.validateLogin(username1, password1);

            this.Hide();
            new MainMenu().Show();
        }
        private void UserTb_TextChanged(object sender, EventArgs e)
        {
            LoginBtn.Enabled = true;
        }
        private void PassTb_TextChanged(object sender, EventArgs e)
        {
            LoginBtn.Enabled = true;
        }
    }
}
