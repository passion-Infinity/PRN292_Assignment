using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationAPI.BLL;
using ReservationDTO.DTO;

namespace Test
{
    public partial class Form1 : Form
    {
        UserBLL bll = new UserBLL();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Login()
        {
            string userID = "nlcdanh";
            string password = "1234";
            UserDTO dto = bll.CheckLogin(userID, password);
            if (dto != null)
            {
                Console.WriteLine("Thanh cong");
                label1.Text = "Thanh Cong";
            }
            else
            {
                Console.WriteLine("That bai");
                label1.Text = "That bai";
            }
        }

        private void Register()
        {
            string userID = "abcdef";
            string fullName = "ABCDEF";
            string password = "1234";
            string phone = "0323456789";
            string email = "abcdef@gmail.com";
            string identityCard = "278965489";
            string gender = "Female";
            string address = "Tay Ninh";
            string role = "customer";
            bool status = true;
            DateTime createdDate = DateTime.Now;
            UserDTO dto = new UserDTO
            {
                UserID = userID,
                FullName = fullName,
                Password = password,
                Phone = phone,
                Email = email,
                IdentityCard = identityCard,
                Gender = gender,
                Address = address,
                Role = role,
                Status = status,
                CreatedDate = createdDate
            };
            if (bll.RegisterAccount(dto))
            {
                Console.WriteLine("Thanh cong");
                label1.Text = "Thanh Cong";
            }
            else
            {
                Console.WriteLine("That bai");
                label1.Text = "That bai";
            }
        }

        private void UpdateAccount()
        {
            string userID = "abc";
            string fullName = "ABCabc";
            string password = "123456789";
            string phone = "0323456789";
            string email = "abc@gmail.com";
            string identityCard = "278965489";
            string gender = "Female";
            string address = "Dak Nong";
            string role = "customer";
            bool status = true;
            DateTime modifiedDate = DateTime.Now;
            UserDTO dto = new UserDTO
            {
                UserID = userID,
                FullName = fullName,
                Password = password,
                Phone = phone,
                Email = email,
                IdentityCard = identityCard,
                Gender = gender,
                Address = address,
                Role = role,
                Status = status,
                ModifiedDate = modifiedDate
            };
            if (bll.UpdateAccount(dto))
            {
                Console.WriteLine("Thanh cong");
                label1.Text = "Thanh Cong";
            }
            else
            {
                Console.WriteLine("That bai");
                label1.Text = "That bai";
            }
        }

        private void DeleteAccount()
        {
            string userID = "abc";
            bool status = false;
            DateTime modifiedDate = DateTime.Now;
            UserDTO dto = new UserDTO
            {
                UserID = userID,
                Status = status,
                ModifiedDate = modifiedDate
            };
            if (bll.DeleteAccount(dto))
            {
                Console.WriteLine("Thanh cong");
                label1.Text = "Thanh Cong";
            }
            else
            {
                Console.WriteLine("That bai");
                label1.Text = "That bai";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Login();
            //Register();
            //UpdateAccount();
            DeleteAccount();
        }
    }
}
