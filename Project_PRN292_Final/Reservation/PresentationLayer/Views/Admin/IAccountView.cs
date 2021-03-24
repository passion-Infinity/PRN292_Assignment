using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Views.Admin
{
    public interface IAccountView : IView
    {
        string UserID { get; set; }
        string FullName { get; set; }
        string Password { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string IdentityCard { get; set; }
        string Gender { get; }
        string Address { get; set; }
        string Image { get; set; }
        bool Status { get; set; }
        string Message { get; set; }
        string Search { get; set; }
    }
}
