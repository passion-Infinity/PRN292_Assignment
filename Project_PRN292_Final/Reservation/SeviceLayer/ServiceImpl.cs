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
        ICategoryDAO categoryDAO;
        IRoomDAO roomDAO;
        public ServiceImpl()
        {
            accountDAO = new AccountDAO();
            categoryDAO = new CategoryDAO();
            roomDAO = new RoomDAO();
        }

        public User CheckLogin(string userID, string password)
        {
            return accountDAO.CheckLogin(userID, password);
        }

        public bool DisableAccount(User user)
        {
            return accountDAO.DisableAccount(user);
        }

        public DataTable GetAllAccounts()
        {
            return accountDAO.GetAll();
        }

        public DataTable FindByName(string name)
        {
            return accountDAO.FindByName(name);
        }

        public bool RegisterAccount(User user)
        {
            return accountDAO.RegisterAccount(user);
        }

        public bool UpdateAccount(User user)
        {
            return accountDAO.UpdateAccount(user);
        }

        public DataTable GetAllCategories()
        {
            return categoryDAO.GetAll();
        }
        public bool AddNewRoomType(RoomType roomType)
        {
            return categoryDAO.AddNewRoomType(roomType);
        }
        public bool UpdateRoomType(RoomType roomType)
        {
            return categoryDAO.UpdateRoomType(roomType);
        }

        public DataTable GetAllRooms()
        {
            return roomDAO.GetAllRooms();
        }

        public DataTable FindRoomsByRoomID(string roomID)
        {
            return roomDAO.FindByRoomID(roomID);
        }

        public bool AddNewRoom(Room room)
        {
            return roomDAO.AddNewRoom(room);
        }

        public bool UpdateRoom(Room room)
        {
            return roomDAO.UpdateRoom(room);
        }

        public bool DisableRoom(Room room)
        {
            return roomDAO.DeleteRoom(room);
        }
    }
}
