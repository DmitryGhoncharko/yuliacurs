﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
   public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=212.113.123.162;database=yulia;user=yulia;password=M59Mty|kei<k~R;";
        private int currentQuestionId = 1;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadQuestion();
        }

        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void LoadQuestion()
        {
            string query = "SELECT QuestionText FROM Questions WHERE QuestionID = @QuestionID";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@QuestionID", currentQuestionId);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblQuestion.Text = reader["QuestionText"].ToString();
            }
            reader.Close();
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

            int correctAnswer = (int)cmd.ExecuteScalar();
            if (userAnswer == correctAnswer)
            {
                score++;
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show("Incorrect. The correct answer is " + correctAnswer);
            }

            currentQuestionId++;
            if (currentQuestionId > 4) // Assuming 4 questions
            {
                SaveResult();
                MessageBox.Show("Game over! Your score is " + score);
                ResetGame();
            }
            else
            {
                LoadQuestion();
            }
        }

        private void SaveResult()
        {
            string query = "INSERT INTO UserResults (UserName, Score) VALUES (@UserName, @Score)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Score", score);
            cmd.ExecuteNonQuery();
        }

        private void ResetGame()
        {
            currentQuestionId = 1;
            score = 0;
            LoadQuestion();
        }
    }
}