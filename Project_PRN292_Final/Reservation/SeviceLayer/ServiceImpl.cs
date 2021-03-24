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
    }
}
