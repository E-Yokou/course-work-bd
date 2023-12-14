using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using courseDataBase.Connection;

namespace courseDataBase
{
    public partial class Add_Data : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Data()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)
        }

        private void BUT_Save_Click(object sender, EventArgs e)
        {
            // создаём соединение с db
            dataBase.OpenConnection();

            var numberRoute = textBox_NUMBERROUTE.Text;
            var cityStart = textBox_CITY.Text;
            var cityFinish = textBox_STOPOVER.Text;
            var timeTravel = textBox_TIMETRAVEL.Text;
            var date = textBox_DATE.Text;
            int price; int idBus;

            if(int.TryParse(textBox_PRICE.Text, out price) && int.TryParse(textBox_IDBUS.Text, out idBus)) 
            {
                // создаём запрос на отправку данных в DB
                var querystring = $"insert into route (number_route, city_start, city_finish, time_travel, date_, price, id_bus) values ('{numberRoute}','{cityStart}','{cityFinish}','{timeTravel}','{date}','{price}', '{idBus}')";

                // вносим запрос в DB
                var command = new SqlCommand(querystring, dataBase.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Цена и id автобуса должна иметь числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region textbox
        private void textBox_CITY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_STOPOVER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_PRICE_KeyPress(object sender, KeyPressEventArgs e)
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
