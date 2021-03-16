using System;
using ReservationAPI.BLL;
using ReservationDTO.DTO;

namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserBLL bll = new UserBLL();
            string userID = "nlcdanh";
            string password = "123";
            UserDTO dto = bll.CheckLogin(userID, password);
            if(dto != null)
            {
                Console.WriteLine("Thành công");
            } else
            {
                Console.WriteLine("Thất bại");
            }
        }
    }
}
