using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataLayer.DB
{
    public class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            string strConnection = @"server=SE140834\SQLEXPRESS;database=PRN292_Assignment;uid=ealflm;pwd=";
            SqlConnection conn = new SqlConnection(strConnection);
            return conn;
        }
    }
}
