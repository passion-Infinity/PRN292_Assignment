using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BusinessObjects;
using DataLayer.IDAO;

namespace DataLayer.DAOimpl
{
    public class RoomDAO : DataProvider, IRoomDAO
    {
        public bool AddNewRoom(Room room)
        {
            string sql = "spAddNewRoom";
            string parameter = "@roomID,@roomTypeID,@price,@image,@status,@createdDate";
            object[] value = {room.RoomID, room.RoomTypeID, room.Price, room.Image, room.Status, room.CreatedDate};
            return ExecuteNonQuery(sql, parameter, value);
        }

        public bool DeleteRoom(Room room)
        {
            string sql = "spUpdateStatusRoom";
            string parameter = "@roomID,@status,@modifiedDate";
            object[] value = { room.RoomID, room.Status, room.ModifiedDate };
            return ExecuteNonQuery(sql, parameter, value);
        }

        public DataTable FindByRoomID(string roomID)
        {
            string sql = "Select * from tblRooms Where RoomID Like '%" + roomID + "%'";
            return ExecuteQuery(sql);
        }

        public DataTable GetAllRooms()
        {
            string sql = "Select r.RoomID, c.RoomTypeName, r.Price, r.Image, r.Status, r.CreatedDate, r.ModifiedDate from tblRooms r " +
                "join tblRoomType c On c.RoomTypeID = r.RoomTypeID";
            return ExecuteQuery(sql);
        }

        public bool UpdateRoom(Room room)
        {
            string sql = "spUpdateRoom";
            string parameter = "@roomID,@roomTypeID,@price,@image,@status,@modifiedDate";
            object[] value = { room.RoomID, room.RoomTypeID, room.Price, room.Image, room.Status, room.ModifiedDate };
            return ExecuteNonQuery(sql, parameter, value);
        }
    }
}
