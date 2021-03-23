using BusinessObjects.BusinessRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class RoomType : BusinessObject
    {
        public RoomType()
        {
            AddRule(new ValidateId("RoomID"));

            AddRule(new ValidateRequired("RoomTypeName"));
            AddRule(new ValidateLength("RoomTypeName", 1, 50));

            AddRule(new ValidateRequired("People"));
        }
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public int People { get; set; }
    }
}
