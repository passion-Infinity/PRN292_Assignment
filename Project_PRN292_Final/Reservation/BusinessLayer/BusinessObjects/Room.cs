using BusinessObjects.BusinessRules;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessObjects
{
    public class Room : BusinessObject
    {
        public Room()
        {
        }
        public string RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
