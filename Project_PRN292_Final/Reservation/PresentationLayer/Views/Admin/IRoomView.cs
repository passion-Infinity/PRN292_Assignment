using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Views.Admin
{
    public interface IRoomView : IView
    {
        string RoomID { get; set; }
        int Category { get; set; }
        float Price { get; set; }
        bool Status { get; set; }
        string Message { get; set; }
        string Search { get; set; }
    }
}
