using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationManagement.Views.Admin
{
    interface IAccountForm
    {
        string UserID { get; set; }
        string FullName { get; set; }
        string Password { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string IdentityCard { get; set; }
        string Gender { get;}
        string Address { get; set; }
        string Image { get; set; }
        bool Status { get; set; }
        string Message { get; set; }
    }
}
