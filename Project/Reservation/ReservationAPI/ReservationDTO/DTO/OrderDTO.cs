using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationDTO.DTO
{
    public class OrderDTO
    {
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
    }
}
