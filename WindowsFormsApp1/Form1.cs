using System;
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
        public Form1()
        {
            InitializeComponent();

            // Добавление кнопок регистрации и входа
            Button btnRegister = new Button();
            btnRegister.Text = "Регистрация";
            btnRegister.Click += (s, e) => {
                RegisterForm registerForm = new RegisterForm();
                registerForm.Show();
            };
            this.Controls.Add(btnRegister);

            Button btnLogin = new Button();
            btnLogin.Text = "Войти";
            btnLogin.Click += (s, e) => {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            };
            this.Controls.Add(btnLogin);

            // Установка расположения кнопок
            btnRegister.Location = new Point(10, 10);
            btnLogin.Location = new Point(100, 10);
        }
    }
}