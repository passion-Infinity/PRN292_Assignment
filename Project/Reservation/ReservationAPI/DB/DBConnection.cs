using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ReservationAPI.DB
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            string strConnection = @"server=SE140655\SQLEXPRESS;database=PRN292_Assignment;uid=sa;pwd=danh123";
            SqlConnection conn = new SqlConnection(strConnection);
            return conn;
        }
    }
}
