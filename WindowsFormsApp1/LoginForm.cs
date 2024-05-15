using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=212.113.123.162;database=yulia;user=yulia;password=M59Mty|kei<k~R;";

        public LoginForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT UserID, RoleID FROM Users WHERE UserName = @UserName AND Password = @Password";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int userId = reader.GetInt32("UserID");
                int roleId = reader.GetInt32("RoleID");
                reader.Close();

                if (roleId == 1)
                {
                    // Admin
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else if (roleId == 2)
                {
                    // Client
                    ClientForm clientForm = new ClientForm(userId);
                    clientForm.Show();
                }
                this.Hide();
            }
            else
            {
                reader.Close();
                MessageBox.Show("Invalid login credentials.");
            }
        }
    }
}
