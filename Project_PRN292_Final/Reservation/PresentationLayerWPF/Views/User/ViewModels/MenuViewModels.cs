using PresentationLayerWPF.Views.User.Models;
using System;
using System.Collections.ObjectModel;

namespace PresentationLayerWPF.Views.User.ViewModels {
    class MenuViewModels {
        ObservableCollection<MenuModel> _menuItems { get; set; }

        public ObservableCollection<MenuModel> MenuItems {
            get { return _menuItems; }
            set { _menuItems = value; }
        }

        public MenuViewModels() {
            _menuItems = new ObservableCollection<MenuModel>() {
                new MenuModel() {
                    MenuName = "Search",
                    Icon = "Magnify",
                    Source = new Uri("Pages/Search.xaml", UriKind.Relative)
                },
                new MenuModel() {
                    MenuName = "Cart",
                    Icon = "Cart",
                    Source = new Uri("Pages/Search.xaml", UriKind.Relative)
                },
                new MenuModel() {
                    MenuName = "Order History",
                    Icon = "History",
                    Source = new Uri("Pages/Search.xaml", UriKind.Relative)

                },
                new MenuModel() {
                    MenuName = "Message",
                    Icon = "Message",
                    Source = new Uri("Pages/Search.xaml", UriKind.Relative)

                },
                new MenuModel() {
                    MenuName = "Setting",
                    Icon = "Setting",
                    Source = new Uri("Pages/Search.xaml", UriKind.Relative)

                }
            };
        }
    }
}
