using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ReservationAPI.DB;
using ReservationDTO.DTO;

namespace ReservationAPI.DAL
{
    class RoomDAO : AbstractDAO
    {
        public bool AddNewRoom(RoomDTO dto)
        {
            string sql = "spAddNewRoom";
            string parameter = "@roomTypeID,@roomName,@price,@status,@createdDate";
            object[] value = {dto.RoomTypeID, dto.RoomName, dto.Price, dto.Status, dto.CreatedDate};
            return ExecuteNonQuery(sql, parameter, value);
        }
        public bool UpdateRoom(RoomDTO dto)
        {
            string sql = "spUpdateRoom";
            string parameter = "@roomID,@roomTypeID,@roomName,@price,@status,@modifiedDate";
            object[] value = { dto.RoomTypeID, dto.RoomName, dto.Price, dto.Status, dto.ModifiedDate };
            return ExecuteNonQuery(sql, parameter, value);
        }
        public bool DeleteRoom(RoomDTO dto)
        {
            string sql = "spUpdateStatusRoom";
            string parameter = "@roomID,@status,@modifiedDate";
            object[] value = { dto.RoomTypeID, dto.Status, dto.ModifiedDate };
            return ExecuteNonQuery(sql, parameter, value);
        }
    }
}
