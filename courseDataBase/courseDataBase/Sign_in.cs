using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using courseDataBase.Connection;

namespace courseDataBase
{
    public partial class Sign_in : Form
    {
        DataBase dataBase = new DataBase();

        public int id_user;

        public Sign_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)

            // временное заполнение полей
            textBox_login.Text = "employeer";
            textBox_password.Text = "employeer";
        }

        private void log_in_load(object sender, EventArgs e)
        {
            // шифрование пароля и выставление ограничений на кол-во символов по таблице SQL
            textBox_password.PasswordChar = '•';
            pictureBox_HIDEPASSWORD.Visible = false;
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void pictureBox_SHOWPASSWORD_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            pictureBox_HIDEPASSWORD.Visible = true;
            pictureBox_SHOWPASSWORD.Visible = false;
        }

        private void pictureBox_HIDEPASSWORD_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
            pictureBox_HIDEPASSWORD.Visible = false;
            pictureBox_SHOWPASSWORD.Visible = true;
        }

        private void BUT_Enter_Click(object sender, EventArgs e)
        {
            // переменные для сбора информации с текстовых полей
            var loginUser = textBox_login.Text;
            var passUser = md5.hashPassword(textBox_password.Text);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            // авторизация клиента ClientRadio
            if (ClientRadio.Checked)
            {
                // переменная с запросом для DB
                string queryString = $"SELECT id_employee, login_employee, password_employee FROM register_employee WHERE login_employee = '{loginUser}' and password_employee = '{passUser}'";

                // запрос для DB
                SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    string queryStringIdUser = $"SELECT id_employee FROM register_employee WHERE login_employee = '{loginUser}' and password_employee = '{passUser}'";

                    dataBase.OpenConnection();

                    // Создание команды SQL
                    SqlCommand command1 = new SqlCommand(queryStringIdUser, dataBase.GetConnection());

                    // Выполнение запроса и запись результата в переменную
                    id_user = Convert.ToInt32(command1.ExecuteScalar());

                    dataBase.CloseConnection();

                    MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeePage userPage = new EmployeePage();
                    //this.Hide();
                    userPage.ShowDialog();
                }
                else
                    MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // авторизация админа AdminRadio
            else if (AdminRadio.Checked)
            {
                // переменная с запросом для DB
                string queryString = $"SELECT id_register_admin, login_admin, password_admin FROM register_admin WHERE login_admin = '{loginUser}' and password_admin = '{passUser}'";

                // запрос для DB
                SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminPage adminPage = new AdminPage();
                    //this.Hide();
                    adminPage.ShowDialog();
                }
                else
                    MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не выбран тип учетной записи!");
                return;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_up frm_sign_up = new Sign_up();
            frm_sign_up.Show();
            this.Hide();
        }
    }
}
