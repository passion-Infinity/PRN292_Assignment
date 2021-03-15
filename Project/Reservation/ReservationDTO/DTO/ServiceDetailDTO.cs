using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationDTO.DTO
{
    class ServiceDetailDTO
    {
        public int ServiceDetailID { get; set; }
        public int ServiceID { get; set; }
        public int OrderDetailID { get; set; }
        public float Price { get; set; }
    }
}
