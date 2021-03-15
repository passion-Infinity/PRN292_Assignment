using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationDTO.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailID { get; set; }
        public string OrderID { get; set; }
        public int RoomID { get; set; }
        public float Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
