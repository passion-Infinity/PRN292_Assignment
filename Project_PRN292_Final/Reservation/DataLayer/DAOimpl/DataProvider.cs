using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataLayer.DB;

namespace DataLayer.DAOimpl
{
    public class DataProvider
    {
        protected bool ExecuteNonQuery(string sql, string str, object[] value = null)
        {
            bool check = false;
            SqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            string[] listItems = str.Split(',');
            if (value != null)
            {
                int i = 0;
                foreach (string item in listItems)
                {
                    cmd.Parameters.Add(new SqlParameter(item, value[i]));
                    i++;
                }
            }
            check = cmd.ExecuteNonQuery() > 0;
            conn.Close();
            return check;
        }

        protected DataTable ExecuteQuery(string sql, object[] parameters = null)
        {
            SqlConnection conn = DBConnection.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (parameters != null)
            {
                string[] listItems = sql.Split(' ');
                int i = 0;
                foreach (string item in listItems)
                {
                    if (item.Contains('@'))
                    {
                        cmd.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable result = new DataTable();
            da.Fill(result);
            conn.Close();
            return result;
        }
    }
}
