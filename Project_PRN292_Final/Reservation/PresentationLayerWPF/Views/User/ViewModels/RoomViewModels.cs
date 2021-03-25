using PresentationLayerWPF.Views.User.Models;
using System;
using System.Collections.ObjectModel;

namespace PresentationLayerWPF.Views.User.ViewModels {
    class RoomViewModels {
        ObservableCollection<RoomModel> _roomItems { get; set; }

        public ObservableCollection<RoomModel> RoomItems {
            get { return _roomItems; }
            set { _roomItems = value; }
        }

        public RoomViewModels() {
            _roomItems = new ObservableCollection<RoomModel>() {
                new RoomModel() {
                    RoomName = "Pro",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/001.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/002.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/003.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/004.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/005.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/006.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/007.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/008.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/009.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/010.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/002.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/003.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/004.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/005.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/006.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/007.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/008.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/009.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/010.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/002.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/003.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/004.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/005.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/006.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/007.jpg"
                },
                new RoomModel() {
                    RoomName = "Vip",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/008.jpg"
                },
                new RoomModel() {
                    RoomName = "New",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/009.jpg"
                },
                new RoomModel() {
                    RoomName = "Free",
                    Price = 2000,
                    RoomTypeID = 1,
                    Image = "/Assets/010.jpg"
                }


            };
        }
    }
}
