using PresentationLayerWPF.Views.User.Models;
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
                    MenuName ="Search",
                    Icon = "Magnify"
                },
                new MenuModel() {
                    MenuName ="Cart",
                    Icon = "Cart"
                },
                new MenuModel() {
                    MenuName ="Order History",
                    Icon = "History"
                },
                new MenuModel() {
                    MenuName ="Message",
                    Icon = "Message"
                }
            };
        }
    }
}
