using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class StaffDashboard : Form
    {
        SqlConnection con = new SqlConnection(
          @"Data Source=DESKTOP-9SQ0N8R\SQLEXPRESS;Initial Catalog=HotelDB2;Integrated Security=True");
        public StaffDashboard()
        {
            InitializeComponent();
            tabStaff.Appearance = TabAppearance.FlatButtons;
            tabStaff.ItemSize = new Size(0, 1);
            tabStaff.SizeMode = TabSizeMode.Fixed;

            cmbRoomStatus.Items.Add("Available");
            cmbRoomStatus.Items.Add("Booked");
            cmbRoomStatus.Items.Add("Maintenance");

            LoadDashboard();
            LoadRooms();
            LoadBookings();
            LoadServices();
        }
        void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lblCheckIn_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabCheckInOut_Click(object sender, EventArgs e)
        {

        }

        private void txtInvoiceId_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnLoadBills_Click(object sender, EventArgs e)
        {
            if (txtBookingId.Text == "")
            {
                MessageBox.Show("Enter Booking ID!");
                return;
            }

            string query =
            "UPDATE Bookings SET status='Checked Out' WHERE bookingId=@id";

            try
            {
                CloseConnection();
                OpenConnection();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id",
                Convert.ToInt32(txtBookingId.Text));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Guest Checked Out!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            LoadBookings();
        }

        private void dgvCurrentBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStaffDashboard_Click(object sender, EventArgs e)
        {
            tabStaff.SelectedTab = tabDashboard;
        }

        private void btnRoomStatus_Click(object sender, EventArgs e)
        {
            tabStaff.SelectedTab = tabRoomStatus;

        }

        private void btnStaffBookings_Click(object sender, EventArgs e)
        {
            tabStaff.SelectedTab = tabBookings;

        }

        private void btnCheckInOut_Click(object sender, EventArgs e)
        {
            tabStaff.SelectedTab = tabCheckInOut;
        }

        private void btnStaffServices_Click(object sender, EventArgs e)
        {
            tabStaff.SelectedTab = tabServices;

        }

        int CountData(string query)
        {
            try
            {
                CloseConnection();

                SqlCommand cmd = new SqlCommand(query, con);

                OpenConnection();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                CloseConnection();
            }
        }

        void LoadDashboard()
        {
            lblTotalRooms.Text =
            CountData("SELECT COUNT(*) FROM Rooms").ToString();

            lblAvailableRooms.Text =
            CountData("SELECT COUNT(*) FROM Rooms WHERE status='Available'")
            .ToString();

            lblTodayBookings.Text =
             CountData("SELECT COUNT(*) FROM Bookings WHERE status='Pending'")
             .ToString();

            lblPendingServices.Text =
            CountData("SELECT COUNT(*) FROM Services").ToString();
        }

        private void btnLoadStaffServices_Click(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void btnMarkServiceDone_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Service Completed!");
        }

        private void btnRefreshStaffDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
            LoadRooms();
            LoadBookings();
            LoadServices();
        }
        void LoadRooms()
        {
            SqlDataAdapter da =
            new SqlDataAdapter("SELECT * FROM Rooms", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvStaffRooms.DataSource = dt;
        }
        private void btnLoadRoomsStaff_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }
        void LoadBookings()
        {
            SqlDataAdapter da =
            new SqlDataAdapter("SELECT * FROM Bookings", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvStaffBookings.DataSource = dt;

            dgvCurrentBookings.DataSource = dt;
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {

        }
        void LoadServices()
        {
            SqlDataAdapter da =
            new SqlDataAdapter("SELECT * FROM Services", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvStaffServices.DataSource = dt;
        }

        private void btnLoadStaffBookings_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (txtBookingId.Text == "")
            {
                MessageBox.Show("Enter Booking ID!");
                return;
            }

            string query =
            "UPDATE Bookings SET status='Checked In' WHERE bookingId=@id";

            try
            {
                CloseConnection();
                OpenConnection();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id",
                Convert.ToInt32(txtBookingId.Text));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Guest Checked In!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            LoadBookings();
        }

        private void dgvStaffRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtRoomId.Text =
                dgvStaffRooms.Rows[e.RowIndex]
                .Cells["roomId"].Value.ToString();

                cmbRoomStatus.Text =
                dgvStaffRooms.Rows[e.RowIndex]
                .Cells["status"].Value.ToString();
            }
        }

        private void btnUpdateRoomStatus_Click(object sender, EventArgs e)
        {
            if (txtRoomId.Text == "")
            {
                MessageBox.Show("Select Room First!");
                return;
            }

            string query =
            "UPDATE Rooms SET status=@status WHERE roomId=@id";

            try
            {
                CloseConnection();
                OpenConnection();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id",
                Convert.ToInt32(txtRoomId.Text));

                cmd.Parameters.AddWithValue("@status",
                cmbRoomStatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Room Status Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            LoadRooms();
            LoadDashboard();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStaffLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

