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

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-9SQ0N8R\\SQLEXPRESS;Initial Catalog=MyDatabase2;Integrated Security=True";

            string UserName = txtusername.Text.Trim();
            string Password = txtpassword.Text.Trim();

            string query = "Select * from Users where UserName='"
                + UserName + "' and Password='" + Password + "'";
            SqlCommand command = new SqlCommand(query, con);

            con.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                     Users user = new Users()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Userstype = reader.GetInt32(3)

                    };
                        con.Close();
                        
                        MessageBox.Show("login  successfull");
                        break;
                    }
                }
                //this.Hide();
                //Form1 form1 = new Form1()
                else
                {
                    MessageBox.Show("Invalid user");
                }
            }
        }
        //bool isVisible = false;
        //private void Pnbpassword_Click(object sender, EventArgs e)
        //{
        //    if (isVisible == false)
        //    {
        //        txtpassword.UseSystemPasswordChar = false; // show password
        //        isVisible = true;
        //    }
        //    else
        //    {
        //        txtpassword.UseSystemPasswordChar = true; // hide password
        //        isVisible = false;
        //   }
        //}
    }
}


