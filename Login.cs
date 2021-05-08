using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRent_Camera
{
    class Login
    {
        public void validateLogin (string username1, string password1)
        {
            //validate login 
            if(username1.Equals("jeremy").Equals(true) && password1.Equals("pastibisa").Equals(true))
            {
                MessageBox.Show("Welcome Admin, Have a Nice Day :)");
                
            }

            //validate empty login 
            else if(username1.Equals(string.Empty).Equals(true))
            {
                MessageBox.Show("Please fill the username");
                return;
            }
            else if(password1.Equals(string.Empty).Equals(true))
            {
                MessageBox.Show("Please fill the password");
                return;
            }
            else
            {
                MessageBox.Show("Invalid Username or Password,\n please try again");
                return;
            }

        }
    }
}
