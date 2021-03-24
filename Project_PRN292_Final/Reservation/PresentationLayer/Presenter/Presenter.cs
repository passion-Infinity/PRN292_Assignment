using System;
using System.Collections.Generic;
using System.Text;
using PresentationLayer.Views;
using PresentationLayer.Model;

namespace PresentationLayer.Presenter
{
    public class Presenter<T> where T : IView
    {
        protected static IModel Model { get; private set; }

        static Presenter()
        {
            Model = new Modelimpl();
        }

        public Presenter(T view)
        {
            View = view;
        }

        protected T View { get; private set; }
    }
}
