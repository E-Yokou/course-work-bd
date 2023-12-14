using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using courseDataBase.Connection;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Globalization;

namespace courseDataBase
{
    public partial class EmployeePage : Form
    {
        DataBase dataBase = new DataBase();
        //Sign_in signIn = new Sign_in();
        public EmployeePage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)
        }

        private int selectedRowsValueControl;
        private int selectedRowsValueRoute;
        private int selectedRowsValuenNumberRoute_Route;
        private int selectedRowsValuenNumberRoute_Stopover;
        private int selectedRowsValueStopover;
        private int selectedRowsValuePrice;
        private string selectedRowsValueDate_;
        private string selectedRowsValueTimeTravel;
        private string selectedRowsValueNumberRoute;

        private void UserPage_Load(object sender, EventArgs e)
        {
            CreateColums();
            CreateColumsStopover();
            RefreshDataGridRoute(dataGridView_route);
            RefreshDataGridStopover(dataGridView_stopover);

            CreateColumsControl();
            RefreshDataGridConrol(dataGridView_control);

            DisplayTransactionCount();
        }

        private void BUT_refresh_control_Click(object sender, EventArgs e)
        {
            RefreshDataGridConrol(dataGridView_control);
            DisplayTransactionCount();
        }

        private void BUT_BuyTicket_Click(object sender, EventArgs e)
        {
            if (textBox_client_birthday.Text != string.Empty || textBox_client_fio.Text != string.Empty || textBox_client_passport.Text != string.Empty ||
                label_date_.Text != "-" || label_from.Text != "-" || label_number_route.Text != "-" || label_price.Text != "-" || label_time_travel.Text != "-" ||
                label_where.Text != "-")
            {
                int index = dataGridView_route.CurrentCell.RowIndex;

                DateTime myDateTime = DateTime.Now;

                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                int idBus = -10; int seatNumber = -10;
                var idRoute = dataGridView_route.Rows[index].Cells[0].Value.ToString();
                var registrationNumber = 1;
                var clientFio = textBox_client_fio.Text;
                var clientPassport = textBox_client_passport.Text;
                var clientBirthday = textBox_client_birthday.Text;
                var numberRoute = label_number_route.Text;
                var cityStart = label_from.Text;
                var cityFinish = label_where.Text;
                var timeTravel = label_time_travel.Text;
                var date = label_date_.Text;
                var price = label_price.Text;

                var status = "Ожидает подтверждения";

                //// создаём соединение с db
                dataBase.OpenConnection();

                string queryStringIdBus = $"select id_bus from route where id = {idRoute}";

                string queryStringSeatNumber = $"select count_seats from bus where id = {idRoute}";

                SqlCommand commandIdBus = new SqlCommand(queryStringIdBus, dataBase.GetConnection());

                SqlDataReader readerIdBus = commandIdBus.ExecuteReader();

                if (readerIdBus.Read())
                {
                    idBus = readerIdBus.GetInt32(0);
                }

                readerIdBus.Close();

                SqlCommand commandSeatNumber = new SqlCommand(queryStringSeatNumber, dataBase.GetConnection());

                SqlDataReader readerSeatNumber = commandSeatNumber.ExecuteReader();

                if (readerSeatNumber.Read())
                {
                    seatNumber = readerSeatNumber.GetInt32(0);
                }

                readerSeatNumber.Close();

                // создаём запрос на отправку данных в DB
                var queryString = $"insert into ticket (id_bus, id_route, registration_number, fio_client, passport_client, birthday_client, city_start, city_finish, seat_number, date_start, date_, date_sale, price, confirm) " +
                                                              $"values ('{idBus}','{idRoute}','{registrationNumber}','{clientFio}','{clientPassport}','{clientBirthday}','{cityStart}','{cityFinish}','{seatNumber}','{date}','{timeTravel}','{sqlFormattedDate}','{price}','{status}')";
                //$"values ('{idBus}','{idRoute}','{registrationNumber}','{clientFio}','{clientPassport}','{clientBirthday}','{cityStart}','{cityFinish}','{seatNumber}','{timeTravel}','{date}','{sqlFormattedDate}','{price}','{status}')";

                // вносим запрос в DB
                var command = new SqlCommand(queryString, dataBase.GetConnection());
                command.ExecuteNonQuery();

                dataBase.CloseConnection();

                RefreshDataGridRoute(dataGridView_route);

                MessageBox.Show("Билет создана!", "Требуется подтверждения!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Билет не создана!", "Продолжите заполнение!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BUT_confirm_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();

            var status = "Подтверждено";

            var changeQuery = $"UPDATE ticket SET confirm = '{status}' WHERE id = '{selectedRowsValueControl}'";

            var command = new SqlCommand(changeQuery, dataBase.GetConnection());
            command.ExecuteNonQuery();

            RefreshDataGridControl(dataGridView_control);

            dataBase.CloseConnection();
        }

        private void BUT_refund_1_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();

            var selectedRowIndex = dataGridView_control.CurrentCell.RowIndex;

            var status = "Оформлен Возврат";

            if (dataGridView_control.Rows[selectedRowIndex].Cells[10].Value.ToString() == "Ожидает Возврат")
            {
                var changeQuery = $"UPDATE ticket set confirm = '{status}' where id = '{selectedRowsValueControl}'";

                var command = new SqlCommand(changeQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();

                RefreshDataGridControl(dataGridView_control);
            }

            dataBase.CloseConnection();
        }

        private void BUT_cancel_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();

            var status = "Отклонено";

            var selectedRowIndex = dataGridView_control.CurrentCell.RowIndex;

            if (dataGridView_control.Rows[selectedRowIndex].Cells[10].Value.ToString() != "Подтверждено"
                || dataGridView_control.Rows[selectedRowIndex].Cells[10].Value.ToString() != "Отклонено"
                || dataGridView_control.Rows[selectedRowIndex].Cells[10].Value.ToString() != "Оформлен возврат")
            {

                var changeQuery = $"UPDATE ticket set confirm = '{status}' where id = '{selectedRowsValueControl}'";

                var command = new SqlCommand(changeQuery, dataBase.GetConnection());
                command.ExecuteNonQuery();
            }

            RefreshDataGridControl(dataGridView_control);

            dataBase.CloseConnection();
        }

        private void dataGridView_stopover_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowsValueStopover = e.RowIndex;

                dataGridView_route.Rows.Clear();

                string searchString = $"select * from route where (number_route) like '%" + dataGridView_stopover.Rows[selectedRowsValueStopover].Cells[1].Value.ToString() + "%'";

                SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

                dataBase.OpenConnection();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    ReadSingleRowRoute(dataGridView_route, read);
                }

                read.Close();


                if (selectedRowsValueStopover >= 0 && selectedRowsValueStopover >= 0 && selectedRowsValuePrice >= 0)
                {
                    for (int i = 0; i < dataGridView_route.Rows.Count; i++)
                    {
                        if (dataGridView_route.Rows[i].Cells[1].Value.ToString() == dataGridView_stopover.Rows[selectedRowsValueStopover].Cells[1].Value.ToString())
                        {
                            selectedRowsValueStopover = i;
                            if (selectedRowsValueRoute < dataGridView_route.Rows.Count && selectedRowsValueRoute >= 0)
                            {
                                selectedRowsValueDate_ = dataGridView_route.Rows[selectedRowsValueStopover].Cells[5].Value.ToString();
                                label_from.Text = dataGridView_route.Rows[selectedRowsValueStopover].Cells[2].Value.ToString();
                            }
                        }
                    }

                    selectedRowsValueTimeTravel = dataGridView_stopover.Rows[selectedRowsValueStopover].Cells[3].Value.ToString();

                    label_number_route.Text = dataGridView_route.Rows[selectedRowsValueStopover].Cells[1].Value.ToString();
                    label_where.Text = dataGridView_stopover.Rows[selectedRowsValueStopover].Cells[2].Value.ToString();
                    label_price.Text = dataGridView_stopover.Rows[selectedRowsValueStopover].Cells[4].Value.ToString();

                    //label_date_.Text = selectedRowsValueDate_;
                    label_time_travel.Text = selectedRowsValueTimeTravel;
                }


            }
            //label_date_ = selectedRowsValueDate_;
        }

        private void dataGridView_route_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectedRowsValueNumberRoute = dataGridView_route.Rows[e.RowIndex].Cells[1].Value.ToString();

            selectedRowsValueRoute = e.RowIndex;

            RefreshDataGridStopover(dataGridView_stopover);
        }

        private void dataGridView_control_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowsValueControl = e.RowIndex + 1;
        }

        private void BUT_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridRoute(dataGridView_route);
        }

        private void BUT_refresh_profile_Click(object sender, EventArgs e)
        {
            RefreshDataGridConrol(dataGridView_control);
        }

        private void textBox_SEARCH_FROM_TextChanged(object sender, EventArgs e)
        {
            SearchFrom(dataGridView_route);
        }

        private void textBox_SEARCH_WHERE_TextChanged(object sender, EventArgs e)
        {
            SearchWhere(dataGridView_route);
        }

        private void CreateColums() // инициализация столбцов для dataGridView_route
        {
            dataGridView_route.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_route.Columns.Add("id", "id");
            dataGridView_route.Columns.Add("number_route", "Номер Маршрута");
            dataGridView_route.Columns.Add("city_start", "Выезд");
            dataGridView_route.Columns.Add("city_finish", "Конченая");
            dataGridView_route.Columns.Add("time_travel", "Длительность Маршрута");
            dataGridView_route.Columns.Add("date_", "Время отправления");
            dataGridView_route.Columns.Add("price", "Стоимость");
        }

        private void CreateColumsStopover() // инициализация столбцов для dataGridView_route
        {
            dataGridView_stopover.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_stopover.Columns.Add("id", "id");
            dataGridView_stopover.Columns.Add("number_route", "Номер Главного Маршрута");
            dataGridView_stopover.Columns.Add("city", "Остановка");
            dataGridView_stopover.Columns.Add("arrive", "Время прибытия");
            dataGridView_stopover.Columns.Add("price", "Стоимость");
        }

        private void CreateColumsControl() // инициализация столбцов для dataGridView_control
        {
            dataGridView_control.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_control.Columns.Add("registration_number", "Регистрационный Номер");
            dataGridView_control.Columns.Add("fio_client", "ФИО");
            dataGridView_control.Columns.Add("passport_client", "Паспорт");
            dataGridView_control.Columns.Add("birthday_client", "День Рождения");
            dataGridView_control.Columns.Add("city_start", "Откуда");
            dataGridView_control.Columns.Add("city_finish", "Куда");
            dataGridView_control.Columns.Add("seat_number", "Место");
            dataGridView_control.Columns.Add("date_start", "Время Отбытия");
            dataGridView_control.Columns.Add("date_", "Время Пути");
            dataGridView_control.Columns.Add("date_sale", "Время Покупки");
            dataGridView_control.Columns.Add("price", "Стоимость");
            dataGridView_control.Columns.Add("confirm", "Статус");
        }

        private void RefreshDataGridRoute(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from route";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowRoute(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGridStopover(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"SELECT * FROM stopover where number_route = '{selectedRowsValueNumberRoute}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowStopover(dgw, reader);
            }

            if (selectedRowsValueRoute >= 0 && selectedRowsValueRoute >= 0 && selectedRowsValuePrice >= 0)
            {
                label_number_route.Text = selectedRowsValueNumberRoute;
                label_from.Text = dataGridView_route.Rows[selectedRowsValueRoute].Cells[2].Value.ToString();
                label_where.Text = dataGridView_route.Rows[selectedRowsValueRoute].Cells[3].Value.ToString();
                label_price.Text = dataGridView_route.Rows[selectedRowsValuePrice].Cells[6].Value.ToString();

                label_date_.Text = dataGridView_route.Rows[selectedRowsValueRoute].Cells[5].Value.ToString();
                label_time_travel.Text = dataGridView_route.Rows[selectedRowsValueRoute].Cells[4].Value.ToString();

            }

            reader.Close();

            //label_number_route.Text = selectedRowsValueNumberRoute;
            //label_from.Text = dataGridView_route.Rows[selectedRowsValueStopover].Cells[2].Value.ToString();
            //label_where.Text = dataGridView_stopover.Rows[selectedRowsValueStopover].Cells[3].Value.ToString();
            //label_price.Text = dataGridView_stopover.Rows[selectedRowsValuePrice].Cells[4].Value.ToString();
        }

        private void ReadSingleRowRoute(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetInt32(6));
        }

        private void ReadSingleRowStopover(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4));
        }

        private void ReadSingleRowConrol(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetInt32(6), record.GetString(7), record.GetString(8), record.GetDateTime(9), record.GetInt32(10), record.GetString(11));
        }

        //$"SELECT registration_number, fio_client, passport_client, birthday_client, city_start," +
        //$"city_finish, seat_number, date_, date_sale, confirm FROM ticket";

        private void SearchFrom(DataGridView dgw) // поиск "Откуда"
        {
            dgw.Rows.Clear();
            string searchString = $"select * from route where (city_start) like '%" + textBox_SEARCH_FROM.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowRoute(dgw, read);
            }

            read.Close();

            dataBase.CloseConnection();
        }

        private void SearchWhere(DataGridView dgw) // поиск "Куда"
        {
            dgw.Rows.Clear();
            string searchString = $"select * from route where (city_finish) like '%" + textBox_SEARCH_WHERE.Text + "%'";
            string searchStringStopover = $"select * from stopover where (city) like '%" + textBox_SEARCH_WHERE.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());
            SqlCommand commandStopover = new SqlCommand(searchStringStopover, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowRoute(dgw, read);
            }

            read.Close();

            SqlDataReader readStopover = commandStopover.ExecuteReader();

            dataGridView_stopover.Rows.Clear();

            while (readStopover.Read())
            {
                ReadSingleRowStopover(dataGridView_stopover, readStopover);
            }

            readStopover.Close();

            dataBase.CloseConnection();
        }

        private void RefreshDataGridConrol(DataGridView dgw_control)
        {
            dgw_control.Rows.Clear();

            string queryString = $"SELECT registration_number, fio_client, passport_client, birthday_client, city_start," +
                                        $"city_finish, seat_number, date_start, date_, date_sale, price, confirm FROM ticket";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowConrol(dgw_control, reader);
            }
            reader.Close();
        }

        private void RefreshDataGridControl(DataGridView dgw_control)
        {
            dgw_control.Rows.Clear();

            string queryString = $"SELECT registration_number, fio_client, passport_client, birthday_client, city_start," +
                                        $"city_finish, seat_number, date_start, date_, date_sale, price, confirm FROM ticket";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowConrol(dgw_control, reader);
            }
            reader.Close();
        }

        private void DisplayTransactionCount()
        {
            dataBase.OpenConnection();

            using (SqlCommand command = new SqlCommand("CountTicketsByType", dataBase.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@transactionType", "Подтверждено");

                int transactionCount = Convert.ToInt32(command.ExecuteScalar());

                label_count_transaction.Text = "Подтвержденные билеты: " + transactionCount.ToString();
            }

            using (SqlCommand command = new SqlCommand("CountTicketsByType", dataBase.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@transactionType", "Ожидает подтверждения");

                int transactionCount = Convert.ToInt32(command.ExecuteScalar());

                label_waiting.Text = "Ожидающие подтверждения - билеты: " + transactionCount.ToString();
            }

            using (SqlCommand command = new SqlCommand("CountTicketsByType", dataBase.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@transactionType", "Ожидает возврат");

                int transactionCount = Convert.ToInt32(command.ExecuteScalar());

                label_refund_transaction.Text = "Возвращенных билетов: " + transactionCount.ToString();
            }
        }
        #region textBox
        private void textBox_client_fio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_client_passport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
