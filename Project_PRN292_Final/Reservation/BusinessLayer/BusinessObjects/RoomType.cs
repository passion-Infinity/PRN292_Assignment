using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class RoomType
    {
        public RoomType()
        {
        }
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public int People { get; set; }
    }
}
