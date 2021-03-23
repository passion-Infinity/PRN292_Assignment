using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataLayer.DAOimpl;
using DataLayer.IDAO;

namespace SeviceLayer
{
    public class ServiceImpl : IService
    {
        IAccountDAO accountDAO;
        public ServiceImpl()
        {
            accountDAO = new AccountDAO();
        }
        public bool AddNewRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public bool AddNewRoomType(RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public User CheckLogin(string userID, string password)
        {
            return accountDAO.CheckLogin(userID, password);
        }

        public bool DisableAccount(User user)
        {
            return accountDAO.DisableAccount(user);
        }

        public bool DisableRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public DataTable FindRoomsByRoomID(string roomID)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllAccounts()
        {
            return accountDAO.GetAll();
        }

        public DataTable GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public DataTable GetOrderDetailByOrderID(string orderID)
        {
            throw new NotImplementedException();
        }

        public DataTable GetOrdersByUserID(string userID)
        {
            throw new NotImplementedException();
        }

        public bool RegisterAccount(User user)
        {
            return accountDAO.RegisterAccount(user);
        }

        public bool UpdateAccount(User user)
        {
            return accountDAO.UpdateAccount(user);
        }

        public bool UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoomType(RoomType roomType)
        {
            throw new NotImplementedException();
        }
    }
}
