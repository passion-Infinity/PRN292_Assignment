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
        
    }
}
