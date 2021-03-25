using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjects;

namespace DataLayer.IDAO
{
    public interface IRoomDAO
    {
        DataTable GetAllRooms();
        DataTable FindByRoomID(string roomID);
        bool AddNewRoom(Room room);
        bool UpdateRoom(Room room);
        bool DeleteRoom(Room room);
    }
}
