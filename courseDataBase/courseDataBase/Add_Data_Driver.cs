using courseDataBase.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace courseDataBase
{
    public partial class Add_Data_Driver : Form
    {
        DataBase dataBase = new DataBase();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public Add_Data_Driver()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)
        }

        private void BUT_Save_Click(object sender, EventArgs e)
        {
            // создаём соединение с db
            dataBase.OpenConnection();

            var fio = textBox_FIO.Text;
            var phone = textBox_PHONE.Text;
            int salary, id_bus;
            bool isImage = true;

            if (int.TryParse(textBox_SALARY.Text, out salary) && int.TryParse(textBox_IDBUS.Text, out id_bus))
            {
                // создаём соединение с базой данных
                dataBase.OpenConnection();

                // добавление параметра изображения
                if (pb_show.Image != null)
                {
                    // создаём запрос на отправку данных в БД
                    var querystring = "INSERT INTO driver (fio, phone, salary, id_bus, photo) " +
                                      "VALUES (@fio, @phone, @salary, @id_bus, @photo)";

                    // создание экземпляра команды и передача строки запроса и соединения
                    var command = new SqlCommand(querystring, dataBase.GetConnection());

                    // добавление параметров в команду
                    command.Parameters.AddWithValue("@fio", fio);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@salary", salary);
                    command.Parameters.AddWithValue("@id_bus", id_bus);

                    var photo = new Bitmap(pb_show.Image);
                    using (var memoryStream = new MemoryStream())
                    {
                        photo.Save(memoryStream, ImageFormat.Jpeg);
                        memoryStream.Position = 0;
                        command.Parameters.AddWithValue("@photo", memoryStream.ToArray());
                    }

                    // выполнение команды на добавление записи в БД
                    command.ExecuteNonQuery();
                }
                else
                    isImage = false;

                if (isImage == false)
                {
                    // создаём запрос на отправку данных в БД
                    var querystring = "INSERT INTO driver (fio, phone, salary, id_bus) " +
                                      "VALUES (@fio, @phone, @salary, @id_bus)";

                    // создание экземпляра команды и передача строки запроса и соединения
                    var command = new SqlCommand(querystring, dataBase.GetConnection());

                    // добавление параметров в команду
                    command.Parameters.AddWithValue("@fio", fio);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@salary", salary);
                    command.Parameters.AddWithValue("@id_bus", id_bus);

                    // выполнение команды на добавление записи в БД
                    command.ExecuteNonQuery();

                    dataBase.CloseConnection();
                }
                

                // закрытие соединения с базой данных
                dataBase.CloseConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(textBox_IDBUS.Text == string.Empty)
            {
                // создаём запрос на отправку данных в DB
                var querystring = $"INSERT INTO driver (fio, phone, salary) values ('{fio}','{phone}','{salary}')";

                // создание экземпляра команды и передача строки запроса и соединения
                var command = new SqlCommand(querystring, dataBase.GetConnection());

                // выполнение команды на добавление записи в БД
                command.ExecuteNonQuery();

                    dataBase.CloseConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Зарплата и id-автобуса должны иметь числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BUT_load_image_Click(object sender, EventArgs e)
        {
            InsertImage();
        }

        private void InsertImage()
        {
            pb_show.SizeMode = PictureBoxSizeMode.StretchImage;

            openFileDialog.Filter = "Image Files(*.JPG,*.JPEG,*.PNG)|*.JPG;*.JPEG;*.PNG"; //формат загружаемого файла

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pb_show.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        #region textbox
        private void textBox_FIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_SALARY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_IDBUS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}

