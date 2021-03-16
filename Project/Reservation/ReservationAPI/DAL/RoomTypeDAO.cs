using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ReservationAPI.DB;
using ReservationDTO.DTO;

namespace ReservationAPI.DAL
{
    class RoomTypeDAO : AbstractDAO
    {
        public RoomTypeDTO GetRoomTypeByID(string id)
        {
            RoomTypeDTO result = null;
            string sql = "Select RoomTypeID, RoomTypeName, People Where RoomTypeID=@roomTypeID";
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@roomTypeID", id);
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
                        result = new RoomTypeDTO
                        {
                            RoomTypeID = int.Parse(rd["RoomTypeID"].ToString()),
                            RoomTypeName = rd["RoomTypeName"].ToString(),
                            People = int.Parse(rd["People"].ToString())
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
            return result;
        }
        public bool AddNewRoomType(RoomTypeDTO dto)
        {
            string sql = "spAddNewRoomType";
            string parameter = "@roomTypeName,@people";
            object[] value = {dto.RoomTypeName, dto.People};
            return ExecuteNonQuery(sql, parameter, value);
        }
        public bool UpdateRoomType(RoomTypeDTO dto)
        {
            string sql = "spUpdateRoomType";
            string parameter = "@roomTypeID,@roomTypeName,@people";
            object[] value = {dto.RoomTypeID, dto.RoomTypeName, dto.People};
            return ExecuteNonQuery(sql, parameter, value);
        }
    }
}
