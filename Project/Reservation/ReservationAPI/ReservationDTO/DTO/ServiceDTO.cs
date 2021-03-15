using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationDTO.DTO
{
    public class ServiceDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
    }
}
