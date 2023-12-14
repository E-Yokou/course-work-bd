using System;
using System.Data;
using System.Data.SqlClient;

namespace courseDataBase.Connection
{
    class DataBase
    {
        SqlConnection con = new SqlConnection(@"Data Source=YOKOPC\MSSQLSERVER01;Initial Catalog=testDataBase;Integrated Security=True");

        public void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return con;
        }
    }
}
