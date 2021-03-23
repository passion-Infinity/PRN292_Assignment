using System;
using System.Collections.Generic;
using System.Text;
using ReservationManagement.Views.Admin;
using ReservationDTO.DTO;
using ReservationAPI.BLL;
using System.Data;

namespace ReservationManagement.Presenters
{
    class AccountPresenter
    {
        IAccountForm accountView;
        UserBLL api = new UserBLL();
        

        public AccountPresenter(IAccountForm accountView)
        {
            this.accountView = accountView;
        }
        public DataTable GetAllAccount()
        {
            return api.GetAll();
        }
        public void RegisterAccountForAdmin()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.UserID = accountView.UserID;
            userDTO.FullName = accountView.FullName;
            userDTO.Password = accountView.Password;
            userDTO.Phone = accountView.Phone;
            userDTO.Email = accountView.Email;
            userDTO.IdentityCard = accountView.IdentityCard;
            userDTO.Gender = accountView.Gender;
            userDTO.Address = accountView.Address;
            userDTO.Image = accountView.Image;
            userDTO.Role = "admin";
            userDTO.Status = accountView.Status;
            userDTO.CreatedDate = DateTime.Now;

            if(api.RegisterAccount(userDTO))
            {
                accountView.Message = string.Format("Register successfully");
            }
        }
    }
}
