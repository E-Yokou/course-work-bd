using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using courseDataBase.Connection;

namespace courseDataBase
{
    public partial class Sign_up : Form
    {
        DataBase dataBase = new DataBase();

        public Sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)

            textBox_AdminPass.Visible = false;
            label_password_admin.Visible = false;
        }

        private void log_in_load(object sender, EventArgs e)
        {
            // шифрование пароля и выставление ограничений на кол-во символов по таблице SQL
            textBox_password_2.PasswordChar = '•';
            pictureBox_HIDEPASSWORD.Visible = true;
            textBox_password_2.MaxLength = 50;
            textBox_login_2.MaxLength = 50;
        }

        private void AdminRadio_CheckedChanged(object sender, EventArgs e)
        {
            textBox_AdminPass.Visible = true;
            label_password_admin.Visible = true;

            textBox_employee_birthday_1.Visible = false;
            textBox_employee_fio_1.Visible = false;
            textBox_employee_passport_1.Visible = false;

            label_employee_bithday.Visible = false;
            label_employee_fio.Visible = false;
            label_employee_passport.Visible = false;

            BUT_Create.Location = new System.Drawing.Point(161, 173);
            label_password_admin.Location = new System.Drawing.Point(158, 219);
            textBox_AdminPass.Location = new System.Drawing.Point(161, 238);
        }

        private void ClientRadio_CheckedChanged(object sender, EventArgs e)
        {
            textBox_AdminPass.Visible = false;
            label_password_admin.Visible = false;

            textBox_employee_birthday_1.Visible = true;
            textBox_employee_fio_1.Visible = true;
            textBox_employee_passport_1.Visible = true;

            label_employee_bithday.Visible = true;
            label_employee_fio.Visible = true;
            label_employee_passport.Visible = true; 

            BUT_Create.Location = new System.Drawing.Point(161, 266);
            label_password_admin.Location = new System.Drawing.Point(158, 317);
            textBox_AdminPass.Location = new System.Drawing.Point(161, 336);
        }

        private void BUT_Create_Click(object sender, EventArgs e)
        {
            // регистрация пользователя ClientRadio
            if (EmployeeRadio.Checked)
            {
                textBox_AdminPass.Visible = false;
                label_password_admin.Visible = false;

                // проверка уже существующих пользовательских аккаунтов в BD
                if (CheckClient())
                {
                    return;
                }

                // переменные для сбора информации с текстовых полей
                var login = textBox_login_2.Text;
                var password = md5.hashPassword(textBox_password_2.Text);
                //var fio = textBox_employee_fio_1.Text;
                //var passport = textBox_employee_passport_1.Text;
                //var birthday = textBox_employee_birthday_1.Text;

                // переменная с запросом для DB
                string querystring = $"insert into register_employee(login_employee, password_employee) values('{login}','{password}')";

                //string querystring = $"insert into register_user(login_user, password_user, fio, passport, birthday) values('{login}','{password}','{fio}','{passport}','{birthday}')";

                // запрос для DB
                SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

                dataBase.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                    Sign_in frm_sign_in = new Sign_in();
                    this.Hide();
                    frm_sign_in.ShowDialog();
                }
                else
                    MessageBox.Show("Аккаунт не создан!");
                dataBase.CloseConnection();
            }

            // регистрация админа AdminRadio
            else if (AdminRadio.Checked && md5.hashPassword(textBox_AdminPass.Text) == "21232F297A57A5A743894A0E4A801FC3")
            {
                // проверка уже существующих пользовательских аккаунтов в BD
                if (CheckAdmin())
                {
                    return;
                }

                // переменные для сбора информации с текстовых полей
                var login = textBox_login_2.Text;
                var password = md5.hashPassword(textBox_password_2.Text);

                // переменная с запросом для DB
                string querystring = $"insert into register_admin(login_admin, password_admin) values('{login}','{password}')";

                // запрос для DB
                SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

                dataBase.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                    Sign_in frm_sign_in = new Sign_in();
                    this.Hide();
                    frm_sign_in.ShowDialog();
                }
                else
                    MessageBox.Show("Аккаунт не создан!");
                dataBase.CloseConnection();
            }

            // не выбран элемент Radio
            else
            {
                MessageBox.Show("Не выбран тип учетной записи!");
                return;
            }
        }

        private void pictureBox_SHOWPASSWORD_Click(object sender, EventArgs e)
        {
            textBox_password_2.UseSystemPasswordChar = true;
            pictureBox_HIDEPASSWORD.Visible = true;
            pictureBox_SHOWPASSWORD.Visible = false;
        }

        private void pictureBox_HIDEPASSWORD_Click(object sender, EventArgs e)
        {
            textBox_password_2.UseSystemPasswordChar = false;
            pictureBox_HIDEPASSWORD.Visible = false;
            pictureBox_SHOWPASSWORD.Visible = true;
        }

        private Boolean CheckClient() // метод проверяющий уже существовующих аккаунтов пользователей
        {
            var loginUser = textBox_login_2.Text;
            var passUser = textBox_password_2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string quertsting = $"SELECT id_register_user, login_user, password_user FROM register_user WHERE login_user ='{loginUser}' AND password_user = '{passUser}'";

            SqlCommand sqlCommand = new SqlCommand(quertsting, dataBase.GetConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);

            if(table.Rows.Count > 0 )
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else return false; 
        }

        private Boolean CheckAdmin() // метод проверяющий уже существовующих аккаунтов админов
        {
            var loginUser = textBox_login_2.Text;
            var passUser = textBox_password_2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string quertsting = $"SELECT id_register_admin, login_admin, password_admin FROM register_admin WHERE login_admin ='{loginUser}' AND password_admin = '{passUser}'";

            SqlCommand sqlCommand = new SqlCommand(quertsting, dataBase.GetConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else return false;
        }
    }
}
