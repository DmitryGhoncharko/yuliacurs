using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=212.113.123.162;database=yulia;user=yulia;password=M59Mty|kei<k~R;";
        private int selectedQuestionId;

        public AdminForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadQuestions();
        }

        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void LoadQuestions()
        {
            string query = "SELECT * FROM Questions";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewQuestions.DataSource = dt;
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Questions (QuestionText, Answer) VALUES (@QuestionText, @Answer)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@QuestionText", txtQuestionText.Text);
            cmd.Parameters.AddWithValue("@Answer", int.Parse(txtAnswer.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("Question added successfully!");
            LoadQuestions();
            ClearInputFields();
        }

        private void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Questions SET QuestionText = @QuestionText, Answer = @Answer WHERE QuestionID = @QuestionID";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@QuestionID", selectedQuestionId);
            cmd.Parameters.AddWithValue("@QuestionText", txtQuestionText.Text);
            cmd.Parameters.AddWithValue("@Answer", int.Parse(txtAnswer.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("Question updated successfully!");
            LoadQuestions();
            ClearInputFields();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Questions WHERE QuestionID = @QuestionID";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@QuestionID", selectedQuestionId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Question deleted successfully!");
            LoadQuestions();
            ClearInputFields();
        }

        private void dataGridViewQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewQuestions.Rows[e.RowIndex];
                selectedQuestionId = Convert.ToInt32(row.Cells["QuestionID"].Value);
                txtQuestionText.Text = row.Cells["QuestionText"].Value.ToString();
                txtAnswer.Text = row.Cells["Answer"].Value.ToString();
            }
        }

        private void ClearInputFields()
        {
            txtQuestionText.Clear();
            txtAnswer.Clear();
        }
    }
}