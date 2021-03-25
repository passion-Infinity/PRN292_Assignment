using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;

namespace PresentationLayer.Presenter
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
        }
        public string CheckLogin()
        {
            string result = "";
            User user = Model.CheckLogin(View.Username, View.Password);
            if(user != null)
            {
                result = user.Role;
            }
            return result;
        }
    }
}
