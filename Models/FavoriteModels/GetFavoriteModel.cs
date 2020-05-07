using System;
using System.Collections.Generic;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Models.CoordinateModel;

namespace Full_Stack_Food_Truck_Application.Models.FavoriteModels
{
    public class GetFavoriteModel
    {
        public string Id { get; set; }
        public string Truck_Name { get; set; }
        public string Price { get; set; }
        public decimal Rating { get; set; }
        public string Phone_Number { get; set; }
        public ICollection<getCategoriesOfFavorite> Categories { get; set; }
        public GetCoordinatesModel Coordinates { get; set; }
        public string Location { get; set; }
        public GetUserOfFavoriteModel CreatedBy { get; set; }
    }
}
