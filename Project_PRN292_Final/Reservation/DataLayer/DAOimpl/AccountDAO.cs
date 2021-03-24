using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataLayer.IDAO;
using DataLayer.DB;
using System.Data.SqlClient;
using BusinessObjects;

namespace DataLayer.DAOimpl
{
    public class AccountDAO : DataProvider, IAccountDAO
    {
        public User CheckLogin(string userID, string password)
        {
            User user = null;
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
                        user = new User
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
            return user;
        }

        public bool DisableAccount(User user)
        {
            string sql = "spUpdateStatusAccount";
            string parameter = "@userID,@status,@modifiedDate";
            object[] value = { user.UserID, user.Status, user.ModifiedDate };
            return ExecuteNonQuery(sql, parameter, value);
        }

        public DataTable GetAll()
        {
            string sql = "Select * from tblUsers";
            return ExecuteQuery(sql);
        }

        public DataTable FindByName(string name)
        {
            string sql = "Select * from tblUsers Where FullName Like '%" + name +"%'";
            return ExecuteQuery(sql);
        }

        public bool RegisterAccount(User user)
        {
            string sql = "spRegisterAccount";
            string parameter = "@userID,@fullName,@password,@phone,@email,@identityCard,@gender,@address," +
                "@image,@role,@status,@createdDate";
            object[] value = {user.UserID, user.FullName, user.Password, user.Phone,
                user.Email, user.IdentityCard, user.Gender, user.Address, user.Image, user.Role, user.Status, user.CreatedDate};
            return ExecuteNonQuery(sql, parameter, value);
        }

        public bool UpdateAccount(User user)
        {
            string sql = "spUpdateAccount";
            string parameter = "@userID,@fullName,@password,@phone,@email,@identityCard,@gender,@address," +
                "@image,@role,@status,@modifiedDate";
            object[] value = {user.UserID, user.FullName, user.Password, user.Phone,
                user.Email, user.IdentityCard, user.Gender, user.Address, user.Image, user.Role, user.Status, user.ModifiedDate};
            return ExecuteNonQuery(sql, parameter, value);
        }
    }
}
