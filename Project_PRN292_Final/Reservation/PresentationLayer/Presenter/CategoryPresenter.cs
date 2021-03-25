using System;
using System.Collections.Generic;
using System.Text;
using PresentationLayer.Views.Admin;
using System.Data;
using BusinessObjects;

namespace PresentationLayer.Presenter
{
    class CategoryPresenter : Presenter<ICategoryView>
    {
        public CategoryPresenter(ICategoryView view) : base(view)
        {
        }
        public DataTable GetAll()
        {
            return Model.GetAllCategories();
        }
        public void AddNewRoomType()
        {
            RoomType dto = new RoomType();
            dto.RoomTypeName = View.RoomTypeName;
            dto.People = View.People;

            if (Model.AddNewRoomType(dto))
            {
                View.Message = string.Format("Add new successfully");
            }
        }

        public void UpdateRoomType()
        {
            RoomType dto = new RoomType();
            dto.RoomTypeID = int.Parse(View.RoomTypeID);
            dto.RoomTypeName = View.RoomTypeName;
            dto.People = View.People;

            if (Model.UpdateRoomType(dto))
            {
                View.Message = string.Format("Update successfully");
            }
        }
    }
}
