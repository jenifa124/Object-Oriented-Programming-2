using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(
                     @"Data Source=DESKTOP-9SQ0N8R\SQLEXPRESS;Initial Catalog=HotelDB2;Integrated Security=True");
        private void cbloginShowpassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = cbloginShowpassword.Checked ? '\0' : '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "" || txtPassword.Text == "" || cmbRole.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            string query = "SELECT * FROM Login WHERE userId=@id AND password=@pass AND role=@role AND status=1";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtUserId.Text));
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            cmd.Parameters.AddWithValue("@role", cmbRole.Text);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Login Successful");

                // Role wise dashboard open
                if (cmbRole.Text == "Admin")
                {
                   new AdminDashboard().Show();
                }
                else if (cmbRole.Text == "Staff")
                {
                   new StaffDashboard().Show();
                }
                else if (cmbRole.Text == "Guest")
                {
                    GuestDashboard guest = new GuestDashboard(Convert.ToInt32(txtUserId.Text));
                    guest.Show();
                    this.Hide();
                }

               
            }
            else
            {
                MessageBox.Show("Invalid Login!");
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.Show();
            this.Hide();
           
       

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
