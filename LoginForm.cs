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
            string username, password;
            username = UserTb.Text;
            password = PassTb.Text;
            if (username == "jeremy" && password == "abc123")
            {
                MessageBox.Show("Welcome Admin Have a Nice Day :)");
                this.Hide();
                new MainMenu().Show();
            }
            else if (username == "" && password == "")
            {
                MessageBox.Show("Please fill all field");
            }
            else
            {
                MessageBox.Show("Invalid Username or Password,\n please try again");
            }
        }

    }
}
