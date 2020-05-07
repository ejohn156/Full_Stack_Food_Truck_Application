using System;
using System.Collections.Generic;
using Full_Stack_Food_Truck_Application.Models.CoordinateModel;
using Full_Stack_Food_Truck_Application.Models.FavoriteModels;

namespace Full_Stack_Food_Truck_Application.Models.UserModels
{
    public class GetFavoritesOfUser
    {
        public string Id { get; set; }
        public string Truck_Name { get; set; }
        public string Price { get; set; }
        public decimal Rating { get; set; }
        public string Phone_Number { get; set; }
        public ICollection<getCategoriesOfFavorite> Categories { get; set; }
        public GetCoordinatesModel Coordinates { get; set; }
        public string Location { get; set; }
    }
}
