using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjects;

namespace SeviceLayer
{
    public interface IService
    {
        // User Repository
        User CheckLogin(string userID, string password);
        DataTable GetAllAccounts();
        DataTable FindByName(string name);
        bool RegisterAccount(User user);
        bool UpdateAccount(User user);
        bool DisableAccount(User user);
        

        // Room Type Repository
        //DataTable GetAllCategories();
        //bool AddNewRoomType(RoomType roomType);
        //bool UpdateRoomType(RoomType roomType);

        //// Room Repository
        //DataTable GetAllRooms();
        //DataTable FindRoomsByRoomID(string roomID);
        //bool AddNewRoom(Room room);
        //bool UpdateRoom(Room room);
        //bool DisableRoom(Room room);

        //// Order Repository
        //DataTable GetAllOrders();
        //DataTable GetOrdersByUserID(string userID);

        //// Order detail Repository
        //DataTable GetOrderDetailByOrderID(string orderID);
    }
}
