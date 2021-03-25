using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjects;

namespace DataLayer.IDAO
{
    public interface ICategoryDAO
    {
        DataTable GetAll();
        bool AddNewRoomType(RoomType roomType);
        bool UpdateRoomType(RoomType roomType);
    }
}
