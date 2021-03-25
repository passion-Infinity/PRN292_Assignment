using System;

namespace PresentationLayerWPF.Views.User.Models {
    public class RoomModel {
        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public string RoomName { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
