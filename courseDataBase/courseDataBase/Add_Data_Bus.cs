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
    public partial class Add_Data_Bus : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Data_Bus()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)
        }

        private void BUT_Save_Click(object sender, EventArgs e)
        {
            // создаём соединение с db
            dataBase.OpenConnection();

            var marka = textBox_bus_BRAND.Text;
            var registerNumber = textBox_bus_STATENUMBER.Text;
            int countSeats;

            if (int.TryParse(textBox_bus_SEATS.Text, out countSeats))
            {
                // создаём запрос на отправку данных в DB
                var querystring = $"insert into bus (marka, register_number, count_seats) values ('{marka}','{registerNumber}','{countSeats}')";

                // вносим запрос в DB
                var command = new SqlCommand(querystring, dataBase.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Сидящие места должны иметь числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region textbox
        private void textBox_bus_BRAND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_bus_SEATS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
