using System;
using System.Collections.Generic;
using System.Text;
using PresentationLayer.Views.Admin;
using System.Data;
using BusinessObjects;

namespace PresentationLayer.Presenter
{
    public class RoomPresenter : Presenter<IRoomView>
    {
        public RoomPresenter(IRoomView view) : base(view)
        {
        }
        public DataTable GetAllCategories()
        {
            return Model.GetAllCategories();
        }
        public DataTable GetAllRooms()
        {
            return Model.GetAllRooms();
        }
        public DataTable FindByRoomID()
        {
            return Model.FindByRoomID(View.Search);
        }
        public void AddNewRoom()
        {
            Room room = new Room();
            room.RoomID = View.RoomID;
            room.RoomTypeID = View.Category;
            room.Price = View.Price;
            room.Image = View.Image;
            room.Status = View.Status;
            room.CreatedDate = DateTime.Now;

            if (Model.AddNewRoom(room))
            {
                View.Message = string.Format("Add New successfully");
            }
        }
        public void UpdateRoom()
        {
            Room room = new Room();
            room.RoomID = View.RoomID;
            room.RoomTypeID = View.Category;
            room.Price = View.Price;
            room.Image = View.Image;
            room.Status = View.Status;
            room.ModifiedDate = DateTime.Now;

            if (Model.UpdateRoom(room))
            {
                View.Message = string.Format("Update successfully");
            }
        }
        public void DeleteRoom()
        {
            Room room = new Room();
            room.RoomID = View.RoomID;
            room.Status = false;
            room.ModifiedDate = DateTime.Now;

            if (Model.DeleteRoom(room))
            {
                View.Message = string.Format("Delete successfully");
            }
        }
    }
}
