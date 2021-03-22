using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ReservationAPI.DB;
using ReservationDTO.DTO;

namespace ReservationAPI.DAL
{
    class UserDAO : AbstractDAO
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

        public DataTable GetAll()
        {
            string sql = "Select * from tblUsers";
            return ExecuteQuery(sql);
        }

        public bool RegisterAccount(UserDTO dto)
        {
            string sql = "spRegisterAccount";
            string parameter = "@userID,@fullName,@password,@phone,@email,@identityCard,@gender,@address," +
                "@image,@role,@status,@createdDate";
            object[] value = {dto.UserID, dto.FullName, dto.Password, dto.Phone, 
                dto.Email, dto.IdentityCard, dto.Gender, dto.Address, dto.Image, dto.Role, dto.Status, dto.CreatedDate};
            return ExecuteNonQuery(sql, parameter, value);
        }

        public bool UpdateAccount(UserDTO dto)
        {
            string sql = "spUpdateAccount";
            string parameter = "@userID,@fullName,@password,@phone,@email,@identityCard,@gender,@address," +
                "@image,@role,@status,@modifiedDate";
            object[] value = {dto.UserID, dto.FullName, dto.Password, dto.Phone,
                dto.Email, dto.IdentityCard, dto.Gender, dto.Address, dto.Image, dto.Role, dto.Status, dto.ModifiedDate};
            return ExecuteNonQuery(sql, parameter, value);
        }

        public bool DeleteAccount(UserDTO dto)
        {
            string sql = "spUpdateStatusAccount";
            string parameter = "@userID,@status,@modifiedDate";
            object[] value = {dto.UserID, dto.Status, dto.ModifiedDate};
            return ExecuteNonQuery(sql, parameter, value);
        }
    }
}
