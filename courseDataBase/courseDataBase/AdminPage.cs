using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using courseDataBase.Connection;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace courseDataBase
{
    enum RowState
    {
        Existed,
        Nes,
        Modfield,
        ModfieldNew,
        Deleted,
        Decoration,
        Confirmed
    }

    public partial class AdminPage : Form
    {
        DataBase database = new DataBase();

        int selectedRow;
        int selectedIdBus;
        int selectedRowDriver;
        int selectedIdImage;
        int selectedColumnValue;
        public AdminPage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // стартовая позиция окна (центр)
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView1);
            
            CreateColumsStopover();
            RefreshDataGridStopover(dataGridView_stopover);

            CreateColumsBus();
            RefreshDataGridBus(dataGridView2_bus);

            CreateColumsBusRoute();
            RefreshDataGrid(dataGridView3_busRoute);

            CreateColumsDriver();
            CreateColumsDriverBus();
            RefreshDataGridDriver(dataGridView_driver);

            //CreateColumsConfirmTransaction();
            //RefreshDataGridConfirmtransaction1(dataGridView_Confirm_Transaction);
            DisplayTransactionCount();
        }

        private void BUT_Refresh_Click(object sender, EventArgs e) // кнопка обновления информации в dataGridView
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        //private void BUT_refresh_confirm_transaction1_Click(object sender, EventArgs e)
        //{
        //    RefreshDataGridConfirmtransaction1(dataGridView_Confirm_Transaction);
        //    DisplayTransactionCount();
        //}

        private void BUT_NewPost_Click(object sender, EventArgs e) // кнопка создания новой записи
        {
            Add_Data add_Data = new Add_Data();
            add_Data.Show();
        }

        private void BUT_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow();
            ClearFields();
        }

        private void BUT_Save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void BUT_Change_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

        private void BUT_ClearFields_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void textBox_SEARCH_TextChanged(object sender, EventArgs e) // текстовое поле для осуществление поиска по DataGridView1
        {
            Search(dataGridView1);
        }

        private void textBox_driver_SEARCH_TextChanged(object sender, EventArgs e)
        {
            SearchDriver(dataGridView_driver);
        }

        private void BUT_bus_NewPost_Click(object sender, EventArgs e)
        {
            Add_Data_Bus add_Data_Bus = new Add_Data_Bus();
            add_Data_Bus.Show();
        }

        private void BUT_bus_Delete_Click(object sender, EventArgs e)
        {
            DeleteRowBus();
            ClearFieldsBus();
        }

        private void BUT_bus_Change_Click(object sender, EventArgs e)
        {
            ChangeBus();
            ClearFieldsBus();
        }

        private void BUT_bus_Save_Click(object sender, EventArgs e)
        {
            UpdateBus();
        }
        private void textBox_bus_SEARCH_TextChanged(object sender, EventArgs e)
        {
            Search_Bus(dataGridView2_bus);
        }

        private void BUT_bus_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridBus(dataGridView2_bus);
            ClearFieldsBus();
        }

        private void BUT_driver_NewPost_Click(object sender, EventArgs e)
        {
            Add_Data_Driver add_Data_Driver = new Add_Data_Driver();
            add_Data_Driver.Show();
        }

        private void BUT_driver_Delete_Click(object sender, EventArgs e)
        {
            DeleteRowDriver();
            ClearFieldsDriver();
        }

        private void BUT_driver_Change_Click(object sender, EventArgs e)
        {
            ChangeDriver();
            ClearFieldsDriver();
        }

        private void BUT_driver_Save_Click(object sender, EventArgs e)
        {
            UpdateDriver();
        }

        private void BUT_driver_ClearField_Click(object sender, EventArgs e)
        {
            ClearFieldsDriver();
        }

        private void BUT_driver_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridDriver(dataGridView_driver);
            ClearFieldsDriver();
        }

        private void BUT_stopover_NewPost_Click(object sender, EventArgs e)
        {
            Add_Data_Stopover add_Data_Stopover = new Add_Data_Stopover();
            add_Data_Stopover.Show();
        }

        private void BUT_stopover_Delete_Click(object sender, EventArgs e)
        {
            int index = dataGridView_stopover.CurrentCell.RowIndex;

            dataGridView_stopover.Rows[index].Visible = false;

            if (dataGridView_stopover.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_stopover.Rows[index].Cells[5].Value = RowState.Deleted; // изменение состояние записи
            }
        }

        private void BUT_stopover_Change_Click(object sender, EventArgs e)
        {
            ChangeStopover();
            ClearFieldsStopover();
        }

        private void BUT_stopover_Save_Click(object sender, EventArgs e)
        {
            UpdateStopover();
        }

        private void BUT_refresh_stopover_Click(object sender, EventArgs e)
        {
            RefreshDataGridStopover(dataGridView_stopover);
            ClearFieldsStopover();
        }

        private void BUT_cliear_fields_stopover_Click(object sender, EventArgs e)
        {

        }

        private void textBox_search_stopover_TextChanged(object sender, EventArgs e)
        {

        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_ID.Text;
            var number_route = textBox_NUMBERROUTE.Text;
            var city_start = textBox_CITY.Text;
            var city_finish = textBox_STOPOVER.Text;
            var timeTravel = textBox_TIMETRAVEL.Text;
            var date = textBox_DATE.Text;
            int price; int idBus;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_PRICE.Text, out price) && int.TryParse(textBox_IDBUS.Text, out idBus))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, number_route, city_start, city_finish, timeTravel, date, price, idBus);
                    dataGridView1.Rows[selectedRowIndex].Cells[8].Value = RowState.Modfield;
                }
                else
                    MessageBox.Show("Цена и id автобуса должна иметь числовой формат!");
            }
        }

        private void ChangeStopover()
        {
            var selectedRowIndex = dataGridView_stopover.CurrentCell.RowIndex;

            var id = textBox_stopover_id.Text;
            var number_route = textBox_stopover_number_route.Text;
            var city_finish = textBox_stopover_city_finish.Text;
            var arrive = textBox_stopover_time_arrive.Text;
            var price = textBox_stopover_price.Text;

            if (dataGridView_stopover.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_stopover.Rows[selectedRowIndex].SetValues(id, number_route, city_finish, arrive, price);
                dataGridView_stopover.Rows[selectedRowIndex].Cells[5].Value = RowState.Modfield;

            }
        }

        private void ChangeBus()
        {
            var selectedRowIndex = dataGridView2_bus.CurrentCell.RowIndex;

            var idBus = textBox_bus_ID.Text;
            var brand = textBox_bus_BRAND.Text;
            var registerNumber = textBox_bus_STATENUMBER.Text;
            int countSeats;

            if (dataGridView2_bus.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_bus_SEATS.Text, out countSeats))
                {
                    dataGridView2_bus.Rows[selectedRowIndex].SetValues(idBus, brand, registerNumber, countSeats);
                    dataGridView2_bus.Rows[selectedRowIndex].Cells[4].Value = RowState.Modfield;
                }
                else
                    MessageBox.Show("Количество сидящих мест должна иметь числовой формат!");
            }
        }

        private void ChangeDriver()
        {
            var selectedRowIndex = dataGridView_driver.CurrentCell.RowIndex;

            var idDriver = textBox_driver_ID.Text;
            var fio = textBox_driver_FIO.Text;
            var phone = textBox_driver_PHONE.Text;
            int salary, idBus;

            if (dataGridView_driver.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_driver_SALARY.Text, out salary) && int.TryParse(textBox_driver_IDBUS.Text, out idBus))
                {
                    dataGridView_driver.Rows[selectedRowIndex].SetValues(idDriver, fio, phone, salary, idBus);
                    dataGridView_driver.Rows[selectedRowIndex].Cells[5].Value = RowState.Modfield;
                }
                else
                    MessageBox.Show("Зарплата или id-автобуса должны иметь числовой формат!");
            }
        }

        private void Update()
        {
            database.OpenConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"DELETE FROM route WHERE id = {id}";

                    var command = new SqlCommand(deleteQuerry, database.GetConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modfield)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var number_route = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var cityStart = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var cityFinish = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var timeTravel = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var date = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var price = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var idBus = dataGridView1.Rows[index].Cells[7].Value.ToString();

                    var changeQuery = $"UPDATE route SET number_route = '{number_route}', city_start = '{cityStart}', city_finish = '{cityFinish}', time_travel = '{timeTravel}', date_ = '{date}', price = '{price}', id_bus = '{idBus}' WHERE id = '{id}'";

                    var command = new SqlCommand(changeQuery, database.GetConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.CloseConnection();
        }

        private void UpdateStopover()
        {
            database.OpenConnection();

            for (int index = 0; index < dataGridView_stopover.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_stopover.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_stopover.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"DELETE FROM route WHERE id = {id}";

                    var command = new SqlCommand(deleteQuerry, database.GetConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modfield)
                {
                    var id = dataGridView_stopover.Rows[index].Cells[0].Value.ToString();
                    var number_route = dataGridView_stopover.Rows[index].Cells[1].Value.ToString();
                    var city = dataGridView_stopover.Rows[index].Cells[2].Value.ToString();
                    var arrive = dataGridView_stopover.Rows[index].Cells[3].Value.ToString();
                    var price = dataGridView_stopover.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"UPDATE stopover SET number_route = '{number_route}', city = '{city}', arrive = '{arrive}', price = '{price}' WHERE id = '{id}'";

                    var command = new SqlCommand(changeQuery, database.GetConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.CloseConnection();
        }

        private void UpdateBus()
        {
            database.OpenConnection();

            for (int index = 0; index < dataGridView2_bus.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView2_bus.Rows[index].Cells[4].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView2_bus.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"DELETE FROM bus WHERE id = {id}";

                    var command = new SqlCommand(deleteQuerry, database.GetConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modfield)
                {
                    var id = dataGridView2_bus.Rows[index].Cells[0].Value.ToString();
                    var brand = dataGridView2_bus.Rows[index].Cells[1].Value.ToString();
                    var registerNumber = dataGridView2_bus.Rows[index].Cells[2].Value.ToString();
                    var countSeats = dataGridView2_bus.Rows[index].Cells[3].Value.ToString();

                    var changeQuery = $"update bus set marka = '{brand}', register_number = '{registerNumber}', count_seats = '{countSeats}' where id = '{id}'";

                    var command = new SqlCommand(changeQuery, database.GetConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.CloseConnection();
        }

        private void UpdateDriver()
        {
            database.OpenConnection();

            for (int index = 0; index < dataGridView_driver.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_driver.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_driver.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"DELETE FROM driver WHERE id = {id}";

                    var command = new SqlCommand(deleteQuerry, database.GetConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modfield)
                {
                    var id = dataGridView_driver.Rows[index].Cells[0].Value.ToString();
                    var fio = dataGridView_driver.Rows[index].Cells[1].Value.ToString();
                    var phone = dataGridView_driver.Rows[index].Cells[2].Value.ToString();
                    var salary = dataGridView_driver.Rows[index].Cells[3].Value.ToString();
                    var idBus = dataGridView_driver.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"UPDATE driver SET fio = '{fio}', phone = '{phone}', salary = '{salary}', id_bus = '{idBus}' WHERE id = '{id}'";

                    var command = new SqlCommand(changeQuery, database.GetConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.CloseConnection();
        }


        private void ClearFields()
        {
            textBox_ID.Text = string.Empty;
            textBox_NUMBERROUTE.Text = string.Empty;
            textBox_CITY.Text = string.Empty;
            textBox_STOPOVER.Text = string.Empty;
            textBox_TIMETRAVEL.Text = string.Empty;
            textBox_DATE.Text = string.Empty;
            textBox_ID.Text = string.Empty;
            textBox_PRICE.Text = string.Empty;
        }

        private void ClearFieldsStopover()
        {
            textBox_stopover_id.Text = string.Empty;
            textBox_stopover_number_route.Text = string.Empty;
            textBox_stopover_city_finish.Text = string.Empty;
            textBox_stopover_time_arrive.Text = string.Empty;
            textBox_stopover_price.Text = string.Empty;
        }

        private void ClearFieldsBus()
        {
            textBox_bus_ID.Text = string.Empty;
            textBox_bus_BRAND.Text = string.Empty;
            textBox_bus_STATENUMBER.Text = string.Empty;
            textBox_bus_SEATS.Text = string.Empty;
        }

        private void ClearFieldsDriver()
        {
            textBox_driver_ID.Text = string.Empty;
            textBox_driver_FIO.Text = string.Empty;
            textBox_driver_PHONE.Text = string.Empty;
            textBox_driver_SALARY.Text = string.Empty;
            textBox_driver_IDBUS.Text = string.Empty;
        }

        private void DeleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[index].Cells[8].Value = RowState.Deleted; // изменение состояние записи
            }
        }

        private void DeleteRowBus()
        {
            int index = dataGridView2_bus.CurrentCell.RowIndex;

            dataGridView2_bus.Rows[index].Visible = false;

            if (dataGridView2_bus.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView2_bus.Rows[index].Cells[4].Value = RowState.Deleted; // изменение состояние записи
            }
        }

        private void DeleteRowDriver()
        {
            int index = dataGridView_driver.CurrentCell.RowIndex;

            dataGridView_driver.Rows[index].Visible = false;

            if (dataGridView_driver.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_driver.Rows[index].Cells[5].Value = RowState.Deleted; // изменение состояние записи
            }
        }

        private void Search(DataGridView dgw) // поиск
        {
            dgw.Rows.Clear();
            string searchString = $"SELECT * FROM route WHERE concat (id, number_route, city_start, city_finish, time_travel, date_, price, id_bus) like '%" + textBox_SEARCH.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }

        private void Search_Bus(DataGridView dgw) // поиск
        {
            dgw.Rows.Clear();
            string searchString = $"SELECT * FROM bus WHERE concat (id, marka, register_number, count_seats) like '%" + textBox_bus_SEARCH.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowBus(dgw, read);
            }

            read.Close();
        }

        private void SearchDriver(DataGridView dgw) // поиск
        {
            dgw.Rows.Clear();
            string searchString = $"SELECT * FROM driver WHERE concat (id, fio, phone, salary, id_bus) like '%" + textBox_driver_SEARCH.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowBus(dgw, read);
            }

            read.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // вывод информации из dataGridView1 по нажатию в textBox'ы
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                label_driver_moscow_count.Text = "В Москву должно быть\n2 водителя";

                if (row.Cells[3].Value.ToString() == "Москва")
                    CheckDriversForMoscowBusAndDisplayResult();

                textBox_ID.Text = row.Cells[0].Value.ToString();
                textBox_NUMBERROUTE.Text = row.Cells[1].Value.ToString();
                textBox_CITY.Text = row.Cells[2].Value.ToString();
                textBox_STOPOVER.Text = row.Cells[3].Value.ToString();
                textBox_TIMETRAVEL.Text = row.Cells[4].Value.ToString();
                textBox_DATE.Text = row.Cells[5].Value.ToString();
                textBox_PRICE.Text = row.Cells[6].Value.ToString();
                textBox_IDBUS.Text = row.Cells[7].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_stopover.Rows[selectedRow];

                textBox_stopover_id.Text = row.Cells[0].Value.ToString();
                textBox_stopover_number_route.Text = row.Cells[1].Value.ToString();
                textBox_stopover_city_finish.Text = row.Cells[2].Value.ToString();
                textBox_stopover_time_arrive.Text = row.Cells[3].Value.ToString();
                textBox_stopover_price.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dataGridView2_bus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2_bus.Rows[selectedRow];

                textBox_bus_ID.Text = row.Cells[0].Value.ToString();
                textBox_bus_BRAND.Text = row.Cells[1].Value.ToString();
                textBox_bus_STATENUMBER.Text = row.Cells[2].Value.ToString();
                textBox_bus_SEATS.Text = row.Cells[3].Value.ToString();

                selectedIdBus = int.Parse(row.Cells[0].Value.ToString());
            }

            string searchString = $"SELECT * FROM route WHERE id_bus = '{selectedIdBus}'";

            SqlCommand command = new SqlCommand(searchString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader read = command.ExecuteReader();

            dataGridView3_busRoute.Rows.Clear();

            while (read.Read())
            {
                ReadSingleRow(dataGridView3_busRoute, read);
            }

            read.Close();
        }

        private void dataGridView_driver_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowDriver = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_driver.Rows[selectedRowDriver];

                object cellValueId = row.Cells[4].Value;
                if (cellValueId != null)
                {
                    selectedRowDriver = int.Parse(cellValueId.ToString());
                }

                textBox_driver_ID.Text = row.Cells[0].Value.ToString();
                textBox_driver_FIO.Text = row.Cells[1].Value.ToString();
                textBox_driver_PHONE.Text = row.Cells[2].Value.ToString();
                textBox_driver_SALARY.Text = row.Cells[3].Value.ToString();

                object cellValue = row.Cells[4].Value;
                textBox_driver_IDBUS.Text = cellValue != null ? cellValue.ToString() : string.Empty;

                selectedIdImage = int.Parse(row.Cells[0].Value.ToString());
            }

            string searchString = $"SELECT * FROM bus WHERE id = '{selectedRowDriver}'";
            string searchStringImage = $"SELECT photo FROM driver WHERE id = '{selectedIdImage}'";

            SqlCommand command = new SqlCommand(searchString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader read = command.ExecuteReader();

            dataGridView_driver_bus.Rows.Clear();

            while (read.Read())
            {
                ReadSingleRowBus(dataGridView_driver_bus, read);
            }

            read.Close();

            database.CloseConnection();

            // --------------------- выгрузка фото из DB --------------------- //

            SqlCommand command1 = new SqlCommand(searchStringImage, database.GetConnection());

            database.OpenConnection();

            SqlDataReader readImage = command1.ExecuteReader();

            pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

            if (readImage.Read() && readImage["photo"] != DBNull.Value && readImage["photo"] is byte[])
            {
                byte[] byteArray = (byte[])readImage["photo"];

                using (var ms = new MemoryStream(byteArray))
                {
                    Bitmap image = new Bitmap(ms);
                    pbPhoto.Image = image;
                }
            }
            readImage.Close();
            database.CloseConnection();


            // ---------------------        конец        --------------------- //

        }

        private void CreateColums() // инициализация столбцов для dataGridView1
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("number_route", "Номер Маршрута");
            dataGridView1.Columns.Add("city", "Откуда");
            dataGridView1.Columns.Add("stopover", "Куда");
            dataGridView1.Columns.Add("time_travel", "Длительность Маршрута");
            dataGridView1.Columns.Add("date_", "Время отправления");
            dataGridView1.Columns.Add("price", "Стоимость");
            dataGridView1.Columns.Add("id_bus", "ID автобуса");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumsStopover() // инициализация столбцов для dataGridView1
        {
            dataGridView_stopover.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_stopover.Columns.Add("id", "id");
            dataGridView_stopover.Columns.Add("number_route", "Номер Маршрута");
            dataGridView_stopover.Columns.Add("city", "Остановка");
            dataGridView_stopover.Columns.Add("arrive", "Время");
            dataGridView_stopover.Columns.Add("price", "Цена");
            dataGridView_stopover.Columns.Add("IsNew", String.Empty);
        }
        

        private void CreateColumsBusRoute() // инициализация столбцов для dataGridView3_busRoute
        {
            dataGridView3_busRoute.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView3_busRoute.Columns.Add("id", "id");
            dataGridView3_busRoute.Columns.Add("number_route", "Номер Маршрута");
            dataGridView3_busRoute.Columns.Add("city", "Города");
            dataGridView3_busRoute.Columns.Add("stopover", "Остановки");
            dataGridView3_busRoute.Columns.Add("time_travel", "Длительность Маршрута");
            dataGridView3_busRoute.Columns.Add("date_", "Время отправления");
            dataGridView3_busRoute.Columns.Add("price", "Стоимость");
            dataGridView3_busRoute.Columns.Add("id_bus", "ID автобуса");
            dataGridView3_busRoute.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumsDriver() // инициализация столбцов для dataGridView_driver
        {
            dataGridView_driver.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_driver.Columns.Add("id", "id");
            dataGridView_driver.Columns.Add("fio", "ФИО");
            dataGridView_driver.Columns.Add("phone", "Ном.телефона");
            dataGridView_driver.Columns.Add("salary", "Зарплата");
            dataGridView_driver.Columns.Add("id_bus", "ID управляемого автобуса");
            dataGridView_driver.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumsBus() // инициализация столбцов для dataGridView2_bus
        {
            dataGridView2_bus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2_bus.Columns.Add("id", "id");
            dataGridView2_bus.Columns.Add("marka", "Марка");
            dataGridView2_bus.Columns.Add("register_number", "гос.номер");
            dataGridView2_bus.Columns.Add("count_seats", "Места");
            dataGridView2_bus.Columns.Add("IsNew", String.Empty);
        }

        private void CreateColumsDriverBus() // инициализация столбцов для dataGridView_driver_bus
        {
            dataGridView_driver_bus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_driver_bus.Columns.Add("id", "id");
            dataGridView_driver_bus.Columns.Add("marka", "Марка");
            dataGridView_driver_bus.Columns.Add("register_number", "гос.номер");
            dataGridView_driver_bus.Columns.Add("count_seats", "Места");
            dataGridView_driver_bus.Columns.Add("IsNew", String.Empty);
        }

        //private void CreateColumsConfirmTransaction() // инициализация столбцов для dataGridView_Confirm_Transaction
        //{
        //    dataGridView_Confirm_Transaction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //    dataGridView_Confirm_Transaction.Columns.Add("id", "id Транзакции");
        //    dataGridView_Confirm_Transaction.Columns.Add("id_route", "id Маршрута");
        //    dataGridView_Confirm_Transaction.Columns.Add("id_client", "id Клиента");
        //    dataGridView_Confirm_Transaction.Columns.Add("number_route", "Номер Маршрута");
        //    dataGridView_Confirm_Transaction.Columns.Add("city_start", "Откуда");
        //    dataGridView_Confirm_Transaction.Columns.Add("city_finish", "Куда");
        //    dataGridView_Confirm_Transaction.Columns.Add("time_travel", "Длительность Маршрута");
        //    dataGridView_Confirm_Transaction.Columns.Add("date_", "Время отправления");
        //    dataGridView_Confirm_Transaction.Columns.Add("price", "Стоимость");
        //    dataGridView_Confirm_Transaction.Columns.Add("confirm", "Статус");
        //    dataGridView_Confirm_Transaction.Columns.Add("IsNew", String.Empty);
        //}

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetInt32(6), record.GetInt32(7), RowState.ModfieldNew);
        }

        private void ReadSingleRowStopover(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), RowState.ModfieldNew);
        }

        private void ReadSingleRowDriver(DataGridView dgw, IDataRecord record)
        {
            int? value4 = null;
            if (!record.IsDBNull(4))
            {
                value4 = record.GetInt32(4);
            }

            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), value4, RowState.ModfieldNew);
        }

        private void ReadSingleRowBus(DataGridView dgw_bus, IDataRecord record)
        {
            dgw_bus.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), RowState.ModfieldNew);
        }

        private void ReadSingleRowConfirmtransaction1(DataGridView dgw_contransaction1, IDataRecord record)
        {
            dgw_contransaction1.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetInt32(8), record.GetString(9));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from route";

            SqlCommand command = new SqlCommand(queryString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGridDriver(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from driver";

            SqlCommand command = new SqlCommand(queryString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowDriver(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGridStopover(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from stopover";

            SqlCommand command = new SqlCommand(queryString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowStopover(dgw, reader);
            }
            reader.Close();
        }

        private void RefreshDataGridBus(DataGridView dgw_bus)
        {
            dgw_bus.Rows.Clear();

            string queryString = $"select * from bus";

            SqlCommand command = new SqlCommand(queryString, database.GetConnection());

            database.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowBus(dgw_bus, reader);
            }
            reader.Close();
        }

        //private void RefreshDataGridConfirmtransaction1(DataGridView dgw_contransaction1)
        //{
        //    dgw_contransaction1.Rows.Clear();

        //    string queryString = $"select * from ticket";

        //    SqlCommand command = new SqlCommand(queryString, database.GetConnection());

        //    database.OpenConnection();

        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        ReadSingleRowConfirmtransaction1(dgw_contransaction1, reader);
        //    }
        //    reader.Close();
        //}

        private void dataGridView_Confirm_transaction1CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedColumnValue = e.RowIndex + 1;
        }

        // хранимые процедуры
        private void DisplayTransactionCount()
        {
            database.OpenConnection();

            //using (SqlCommand command = new SqlCommand("CountTransactionsByType", database.GetConnection()))
            //{
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.AddWithValue("@transactionType", "Подтверждено");

            //    int transactionCount = Convert.ToInt32(command.ExecuteScalar());

            //    label_count_transaction.Text = "Подтвержденные транзакции: " + transactionCount.ToString();
            //}

            //using (SqlCommand command = new SqlCommand("CountTransactionsByType", database.GetConnection()))
            //{
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.AddWithValue("@transactionType", "Ожидает подтверждения");

            //    int transactionCount = Convert.ToInt32(command.ExecuteScalar());

            //    label_waiting.Text = "Ожидающие подтверждения - транзакции: " + transactionCount.ToString();
            //}

            //using (SqlCommand command = new SqlCommand("CountTransactionsByType", database.GetConnection()))
            //{
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.AddWithValue("@transactionType", "Ожидает возврат");

            //    int transactionCount = Convert.ToInt32(command.ExecuteScalar());

            //    label_refund_transaction.Text = "Возвращенных транзакций: " + transactionCount.ToString();
            //}

            using (SqlCommand command = new SqlCommand("count_drivers", database.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@totalDrivers", SqlDbType.Int).Direction = ParameterDirection.Output;

                //database.OpenConnection();
                command.ExecuteNonQuery();

                int totalDrivers = (int)command.Parameters["@totalDrivers"].Value;

                label_driver_count.Text = "Количество водителей: " + totalDrivers;
            }

            using (SqlCommand command = new SqlCommand("count_bus", database.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@totalBus", SqlDbType.Int).Direction = ParameterDirection.Output;

                //database.OpenConnection();
                command.ExecuteNonQuery();

                int totalDrivers = (int)command.Parameters["@totalBus"].Value;

                label_bus_count.Text = "Количество автобусов: " + totalDrivers;
            }

            using (SqlCommand command = new SqlCommand("CalculateTotalSalary", database.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;

                //database.OpenConnection();
                var result = command.ExecuteScalar(); // Получение результата процедуры

                // Использование результата в метке
                label_salary_count.Text = "Зарплата водителям: " + result.ToString();
            }

            using (SqlCommand command = new SqlCommand("CalculateTicketPrice", database.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;

                //database.OpenConnection();
                var result = command.ExecuteScalar(); // Получение результата процедуры

                // Использование результата в метке
                label_income.Text = "Доходы: " + result.ToString();
            }

            using (SqlCommand command = new SqlCommand("CountDriverWithoutBus", database.GetConnection()))
            {
                command.CommandType = CommandType.StoredProcedure;

                //database.OpenConnection();
                var result = command.ExecuteScalar(); // Получение результата процедуры

                // Использование результата в метке
                label_driver_without_bus_count.Text = "Количество водителей без ТС: " + result.ToString();
            }
        }

        public void CheckDriversForMoscowBusAndDisplayResult()
        {
            int expectedDriverCount = 2;
            int actualDriverCount = 0;

            database.OpenConnection();

            // Получаем id_bus из таблицы route по условию city_finish = "Москва"
            string selectQuery = "SELECT id_bus FROM route WHERE city_finish = 'Москва'";
            using (SqlCommand command = new SqlCommand(selectQuery, database.GetConnection()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idBus = reader.GetInt32(0);

                        // Проверяем каждый id_bus из таблицы driver с id_bus из таблицы route
                        using (SqlConnection countConnection = new SqlConnection(@"Data Source=YOKOPC\MSSQLSERVER01;Initial Catalog=testDataBase;Integrated Security=True"))
                        {
                            countConnection.Open();
                            string countQuery = $"SELECT COUNT(*) FROM driver WHERE id_bus = {idBus}";
                            using (SqlCommand countCommand = new SqlCommand(countQuery, countConnection))
                            {
                                actualDriverCount += (int)countCommand.ExecuteScalar();
                            }
                        }
                    }
                }
            }

            database.CloseConnection();

            string resultText;
            if (actualDriverCount == expectedDriverCount)
            {
                resultText = "Количество водителей\nсоответствует требуемому";
            }
            else
            {
                resultText = $"Количество водителей\nне соответствует требованиям: {actualDriverCount}";
            }

            label_driver_moscow_count.Text = resultText;
        }

        #region textbox

        private void textBox_driver_FIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_driver_SALARY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_driver_IDBUS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_bus_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void textBox_bus_BRAND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox_bus_STATENUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_bus_SEATS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_stopover_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_stopover_number_route_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox_stopover_city_finish_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox_stopover_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        private void textBox_driver_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
