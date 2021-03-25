using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BusinessObjects;
using DataLayer.IDAO;

namespace DataLayer.DAOimpl
{
    public class CategoryDAO : DataProvider, ICategoryDAO
    {
        public bool AddNewRoomType(RoomType roomType)
        {
            string sql = "spAddNewRoomType";
            string parameter = "@roomTypeName,@people";
            object[] value = {roomType.RoomTypeName,roomType.People};
            return ExecuteNonQuery(sql, parameter, value);
        }

        public DataTable GetAll()
        {
            string sql = "Select * From tblRoomType";
            return ExecuteQuery(sql);
        }

        public bool UpdateRoomType(RoomType roomType)
        {
            string sql = "spUpdateRoomType";
            string parameter = "@roomTypeID,@roomTypeName,@people";
            object[] value = {roomType.RoomTypeID, roomType.RoomTypeName, roomType.People };
            return ExecuteNonQuery(sql, parameter, value);
        }
    }
}
