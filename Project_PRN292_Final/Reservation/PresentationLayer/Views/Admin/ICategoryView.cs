using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Views.Admin
{
    public interface ICategoryView : IView
    {
        string RoomTypeID { get; set; }
        string RoomTypeName { get; set; }
        int People { get; set; }
        string Message { get; set; }
    }
}
