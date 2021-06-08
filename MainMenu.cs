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
    public partial class MainMenu : Form
    {
   
        public MainMenu()
        {
            InitializeComponent();
            RentDateDtp.ValueChanged += new EventHandler(RentDateDtp_ValueChanged);
            ReturnDtp.ValueChanged += new EventHandler(ReturnDtp_ValueChanged);
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\source\repos\eRent Camera\DB_eRent.mdf;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from rentalData";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentalDgv.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            uCustomer iCustomer = new uCustomer();
            Rental iRental = new Rental();
            uRent iRent = new uRent();

            iRental.thePrice = Double.Parse(PriceTb.Text);
            iRent.theDays = int.Parse(DaysTb.Text);

            String q = String.Format("Rp{0}", iRental.thePrice * iRent.theDays);
            FeeTb.Text = q;

            if (IdCustTb.Text == ""|| IdTb.Text == "" || NameTb.Text == "" || AddTb.Text == "" || PhoneTb.Text == "" || RegNoTb.Text == "" || MerkTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "" || DaysTb.Text == "" ||FeeTb.Text=="" )
            {
                MessageBox.Show("You Must Fill all the information needed");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into rentalData values('" + IdCustTb.Text + "','" + IdTb.Text+"','" + IdTypeCb.SelectedItem.ToString() + "', '" + NameTb.Text + "', '" + AddTb.Text + "', '" + PhoneTb.Text + "', " + RegNoTb.Text + ", '" + MerkTb.Text + "','" + ModelTb.Text + "','" + PriceTb.Text + "', '" + RentDateDtp.Value.Date+"', '"+ ReturnDtp.Value.Date +"','" + DaysTb.Text + "', '" + FeeTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information Succesfully Added");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
            
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (IdCustTb.Text == "" || IdTb.Text == "" || NameTb.Text == "" || AddTb.Text == "" || PhoneTb.Text == "" || RegNoTb.Text == "" || MerkTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "" || DaysTb.Text == "" || FeeTb.Text == "")
            {
                MessageBox.Show("Wrong Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update rentalData set [Id No]= '" +IdTb.Text+"',[ID Type]='" + IdTypeCb.SelectedItem.ToString() + "',Name= '" + NameTb.Text + "',Address= '" + AddTb.Text + "', Phone= '" + PhoneTb.Text + "', RegNo='" +RegNoTb.Text+"',Merk= '" + MerkTb.Text + "',Model= '" + ModelTb.Text + "',Price= '" + PriceTb.Text + "', Days= '" + DaysTb.Text + "', [Rent Fee]= '" + FeeTb.Text + "' where [Id]= '" + IdCustTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information Succesfully Update");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(IdCustTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from rentalData where [Id]=" + IdCustTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information Succesfully Deleted");
                    Con.Close();
                    populate();
                }
                catch(Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message);
                }
            }
        }
      
    
        private void RentalDgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {           
            IdTb.Text = RentalDgv.CurrentRow.Cells["Id No"].Value.ToString();
            IdCustTb.Text = RentalDgv.CurrentRow.Cells["Id"].Value.ToString();
            IdTypeCb.SelectedItem = RentalDgv.CurrentRow.Cells["ID Type"].Value.ToString();
            NameTb.Text = RentalDgv.CurrentRow.Cells["Name"].Value.ToString();
            AddTb.Text = RentalDgv.CurrentRow.Cells["Address"].Value.ToString();
            PhoneTb.Text = RentalDgv.CurrentRow.Cells["Phone"].Value.ToString();
            RegNoTb.Text = RentalDgv.CurrentRow.Cells["RegNo"].Value.ToString();
            MerkTb.Text = RentalDgv.CurrentRow.Cells["Merk"].Value.ToString();
            ModelTb.Text = RentalDgv.CurrentRow.Cells["Model"].Value.ToString();
            PriceTb.Text = RentalDgv.CurrentRow.Cells["Price"].Value.ToString();
            RentDateDtp.Text = RentalDgv.CurrentRow.Cells["Rent Date"].Value.ToString();
            ReturnDtp.Text = RentalDgv.CurrentRow.Cells["Return Date"].Value.ToString();
            DaysTb.Text = RentalDgv.CurrentRow.Cells["Days"].Value.ToString();
            FeeTb.Text = RentalDgv.CurrentRow.Cells["Rent Fee"].Value.ToString();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            populate();
            IdTypeCb.Items.Add("KTP");
            IdTypeCb.Items.Add("SIM");
            IdTypeCb.Items.Add("Student Card");
            IdTypeCb.Items.Add("Passport");
        }

        private void RentDateDtp_ValueChanged(object sender, EventArgs e)
        {
            DateTime startTime = Convert.ToDateTime(RentDateDtp.Text);
            DateTime endTime = Convert.ToDateTime(ReturnDtp.Text);
            if (endTime >= startTime)
            {
                DaysTb.Text = endTime.Subtract(startTime).Days.ToString();
            }
        }

        private void ReturnDtp_ValueChanged(object sender, EventArgs e)
        {
            DateTime startTime = Convert.ToDateTime(RentDateDtp.Text);
            DateTime endTime = Convert.ToDateTime(ReturnDtp.Text);
            if (endTime >= startTime)
            {
                DaysTb.Text = endTime.Subtract(startTime).Days.ToString();
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
