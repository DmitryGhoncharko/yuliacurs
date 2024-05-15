using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=212.113.123.162;database=yulia;user=yulia;password=M59Mty|kei<k~R;";

        public RegisterForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                string query = "INSERT INTO Users (UserName, Password, RoleID) VALUES (@UserName, @Password, 2)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registration successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }
    }
}