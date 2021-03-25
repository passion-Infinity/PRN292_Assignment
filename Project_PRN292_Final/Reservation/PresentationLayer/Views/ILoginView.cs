using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Views
{
    public interface ILoginView : IView
    {
        string Username { get; set; }
        string Password { get; set; }
        string Message { get; set; }
    }
}
