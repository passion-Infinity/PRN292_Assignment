using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ReservationAPI.DB;
using ReservationDTO.DTO;

namespace ReservationAPI.DAL
{
    class UserDAO
    {
        public UserDTO CheckLogin(string userID, string password)
        {
            UserDTO dto = null;
            string sql = "Select UserID, FullName, Role From tblUsers Where UserID = @userId And Password = @password";
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@password", password);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        dto = new UserDTO
                        {
                            UserID = rd["UserID"].ToString(),
                            FullName = rd["FullName"].ToString(),
                            Role = rd["Role"].ToString()
                        };
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dto;
        }
    }
}
