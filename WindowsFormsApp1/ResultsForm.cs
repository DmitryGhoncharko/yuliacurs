using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class ResultsForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=212.113.123.162;database=yulia;user=yulia;password=M59Mty|kei<k~R;";
        private int userId;

        public ResultsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeDatabaseConnection();
            LoadUserName(); // Загрузка и отображение имени пользователя
            LoadResults();
        }

        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void LoadUserName()
        {
            string query = "SELECT UserName FROM Users WHERE UserID = @UserID";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", userId);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    lblUserName.Text = "Результаты для: " + reader["UserName"].ToString();
                }
            }
        }

        private void LoadResults()
        {
            string query = @"SELECT ur.UserID, u.UserName, ur.Score 
                             FROM UserResults ur
                             JOIN Users u ON ur.UserID = u.UserID
                             WHERE ur.UserID = @UserID";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", userId);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewResults.DataSource = dt;
        }
    }
}