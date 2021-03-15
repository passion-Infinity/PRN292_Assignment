using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationDTO.DTO
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public string RoomName { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
