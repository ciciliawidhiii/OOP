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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\source\repos\eRent Camera\eRentDb.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT (*) FROM LoginTbl WHERE username= '" + UserTb.Text + "' AND pass= '" + PassTb.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Welcome Admin, Have a Nice Day :)");
                this.Hide();
                new MainMenu().Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");

            }
        }
    }
}
