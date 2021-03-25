using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PresentationLayer.Views.Admin;
using PresentationLayer.Model;
using BusinessObjects;


namespace PresentationLayer.Presenter
{
    public class AccountPresenter : Presenter<IAccountView>
    {

        public AccountPresenter(IAccountView view) :base(view)
        {
        }
        public DataTable GetAll()
        {
            return Model.GetAllAccounts();
        }
        public void RegisterAccountForAdmin()
        {
            User userDTO = new User();
            userDTO.UserID = View.UserID;
            userDTO.FullName = View.FullName;
            userDTO.Password = View.Password;
            userDTO.Phone = View.Phone;
            userDTO.Email = View.Email;
            userDTO.IdentityCard = View.IdentityCard;
            userDTO.Gender = View.Gender;
            userDTO.Address = View.Address;
            userDTO.Image = View.Image;
            userDTO.Role = "admin";
            userDTO.Status = View.Status;
            userDTO.CreatedDate = DateTime.Now;

            if (Model.RegisterAccount(userDTO))
            {
                View.Message = string.Format("Register successfully");
            }
        }
        public void RegisterAccountForCustomer()
        {
            User userDTO = new User();
            userDTO.UserID = View.UserID;
            userDTO.FullName = View.FullName;
            userDTO.Password = View.Password;
            userDTO.Phone = View.Phone;
            userDTO.Email = View.Email;
            userDTO.IdentityCard = View.IdentityCard;
            userDTO.Gender = View.Gender;
            userDTO.Address = View.Address;
            userDTO.Image = "";
            userDTO.Role = "customer";
            userDTO.Status = true;
            userDTO.CreatedDate = DateTime.Now;

            if (Model.RegisterAccount(userDTO))
            {
                View.Message = string.Format("Register successfully");
            }
        }
        public void UpdateAccountForAdmin()
        {
            User userDTO = new User();
            userDTO.UserID = View.UserID;
            userDTO.FullName = View.FullName;
            userDTO.Password = View.Password;
            userDTO.Phone = View.Phone;
            userDTO.Email = View.Email;
            userDTO.IdentityCard = View.IdentityCard;
            userDTO.Gender = View.Gender;
            userDTO.Address = View.Address;
            userDTO.Image = View.Image;
            userDTO.Role = "admin";
            userDTO.Status = View.Status;
            userDTO.ModifiedDate = DateTime.Now;

            if (Model.UpdateAccount(userDTO))
            {
                View.Message = string.Format("Update successfully");
            }
        }
        public void DisableAccountForAdmin()
        {
            User userDTO = new User();
            userDTO.UserID = View.UserID;
            userDTO.Status = false;
            userDTO.ModifiedDate = DateTime.Now;

            if (Model.deleteAccount(userDTO))
            {
                View.Message = string.Format("Delete successfully");
            }
        }
        public DataTable FindByName()
        {
            return Model.FindByName(View.Search);
        }
    }
}
