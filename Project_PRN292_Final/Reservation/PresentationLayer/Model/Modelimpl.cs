﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SeviceLayer;
using BusinessObjects;
using PresentationLayer.Views.Admin;

namespace PresentationLayer.Model
{
    public class Modelimpl : IModel
    {
        IService service;
        public Modelimpl()
        {
            service = new ServiceImpl();
        }
        public DataTable GetAllAccounts()
        {
            return service.GetAllAccounts();
        }
        public DataTable FindByName(string name)
        {
            return service.FindByName(name);
        }
        public bool RegisterAccount(User user)
        {
            return service.RegisterAccount(user);
        }
        public bool UpdateAccount(User user)
        {
            return service.UpdateAccount(user);
        }
        public bool deleteAccount(User user)
        {
            return service.DisableAccount(user);
        }
    }
}
