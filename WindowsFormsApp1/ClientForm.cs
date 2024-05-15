using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class ClientForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=212.113.123.162;database=yulia;user=yulia;password=M59Mty|kei<k~R;";
        private int currentQuestionId = 0; // Initialize to 0
        private int score = 0;
        private int userId;
        private int totalQuestions;
        private int questionNumber = 0; // Counter for question number

        public ClientForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeDatabaseConnection();
            LoadTotalQuestions();
        }

        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void LoadTotalQuestions()
        {
            string query = "SELECT COUNT(*) FROM Questions";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            totalQuestions = Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            ResetTest();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            string query;
            MySqlCommand cmd;

            if (currentQuestionId == 0)
            {
                // Get the first question
                query = "SELECT QuestionID, QuestionText FROM Questions ORDER BY QuestionID ASC LIMIT 1";
                cmd = new MySqlCommand(query, connection);
            }
            else
            {
                // Get the next question
                query = "SELECT QuestionID, QuestionText FROM Questions WHERE QuestionID > @CurrentQuestionID ORDER BY QuestionID ASC LIMIT 1";
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrentQuestionID", currentQuestionId);
            }

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    currentQuestionId = Convert.ToInt32(reader["QuestionID"]);
                    lblQuestion.Text = reader["QuestionText"].ToString();
                    questionNumber++;
                    lblProgress.Text = $"Question {questionNumber} of {totalQuestions}";
                }
                else
                {
                    reader.Close();  // Ensure reader is closed
                    SaveResult();
                    MessageBox.Show("Test completed! Your score is " + score);
                    ResetTest();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int userAnswer;
            if (int.TryParse(txtAnswer.Text, out userAnswer))
            {
                CheckAnswer(userAnswer);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void CheckAnswer(int userAnswer)
        {
            string query = "SELECT Answer FROM Questions WHERE QuestionID = @QuestionID";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@QuestionID", currentQuestionId);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    int correctAnswer = Convert.ToInt32(reader["Answer"]);
                    if (userAnswer == correctAnswer)
                    {
                        score++;
                        MessageBox.Show("Correct!");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect. The correct answer is " + correctAnswer);
                    }
                }
            }

            LoadQuestion();
        }

        private void SaveResult()
        {
            string query = "INSERT INTO UserResults (UserID, Score) VALUES (@UserID, @Score)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Score", score);
            cmd.ExecuteNonQuery();
        }

        private void ResetTest()
        {
            currentQuestionId = 0; // Reset to 0
            questionNumber = 0; // Reset question number
            score = 0;
            lblQuestion.Text = string.Empty;
            lblProgress.Text = string.Empty;
            txtAnswer.Text = string.Empty;
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm(userId);
            resultsForm.Show();
        }
    }
}
