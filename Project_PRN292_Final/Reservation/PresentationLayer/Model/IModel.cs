using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjects;

namespace PresentationLayer.Model
{
    public interface IModel
    {
        DataTable GetAllAccounts();
        DataTable FindByName(string name);
        bool RegisterAccount(User user);
        bool UpdateAccount(User user);
        bool deleteAccount(User user);
        DataTable GetAllCategories();
        bool AddNewRoomType(RoomType roomType);
        bool UpdateRoomType(RoomType roomType);
        DataTable GetAllRooms();
        DataTable FindByRoomID(string roomID);
        bool AddNewRoom(Room room);
        bool UpdateRoom(Room room);
        bool DeleteRoom(Room room);
        User CheckLogin(string username, string password);
    }
}
