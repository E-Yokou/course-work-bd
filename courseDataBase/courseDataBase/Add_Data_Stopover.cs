using courseDataBase.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace courseDataBase
{
    public partial class Add_Data_Stopover : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Data_Stopover()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)

        }

        private void BUT_Save_Click(object sender, EventArgs e)
        {
            // создаём соединение с db
            dataBase.OpenConnection();

            var numberRoute = textBox_stopover_number_route.Text;
            var city = textBox_stopover_city_finish.Text;
            var arrive = textBox_stopover_arrive.Text;
            int price;

            if (int.TryParse(textBox_stopover_price.Text, out price))
            {
                // создаём запрос на отправку данных в DB
                var querystring = $"insert into stopover (number_route, city, arrive, price) values ('{numberRoute}','{city}','{arrive}','{price}')";

                // вносим запрос в DB
                var command = new SqlCommand(querystring, dataBase.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Цена должна иметь числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region textbox
        private void textBox_stopover_arrive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_stopover_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
