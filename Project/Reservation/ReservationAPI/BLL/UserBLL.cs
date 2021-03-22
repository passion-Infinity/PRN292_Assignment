using System;
using System.Collections.Generic;
using System.Text;
using ReservationAPI.DAL;
using ReservationDTO.DTO;
using System.Data;

namespace ReservationAPI.BLL
{
    public class UserBLL
    {
        UserDAO dao;
        public UserBLL()
        {
            dao = new UserDAO();
        }
        public UserDTO CheckLogin(string userID, string password)
        {
            return dao.CheckLogin(userID, password);
        }

        public DataTable GetAll()
        {
            return dao.GetAll();
        }

        public bool RegisterAccount(UserDTO dto)
        {
            return dao.RegisterAccount(dto);
        }

        public bool UpdateAccount(UserDTO dto)
        {
            return dao.UpdateAccount(dto);
        }

        public bool DeleteAccount(UserDTO dto)
        {
            return dao.DeleteAccount(dto);
        }
    }
}
