using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using System.Data;

namespace DataLayer.IDAO
{
    public interface IAccountDAO
    {
        //User CheckLogin(string userID, string password);
        DataTable GetAll();
        User CheckLogin(string userID, string password);
        bool RegisterAccount(User user);
        bool UpdateAccount(User user);
        bool DisableAccount(User user);
    }
}
