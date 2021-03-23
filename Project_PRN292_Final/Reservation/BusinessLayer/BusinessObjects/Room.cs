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
            AddRule(new ValidateId("RoomID"));

            AddRule(new ValidateRequired("RoomName"));
            AddRule(new ValidateLength("RoomName", 1, 50));
            
            AddRule(new ValidateRequired("Price"));
            AddRule(new ValidatePrice("Price"));
        }
        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public string RoomName { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
