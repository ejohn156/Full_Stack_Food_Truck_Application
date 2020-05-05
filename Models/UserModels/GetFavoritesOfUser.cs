using System;
using Full_Stack_Food_Truck_Application.Models.CoordinateModel;

namespace Full_Stack_Food_Truck_Application.Models.UserModels
{
    public class GetFavoritesOfUser
    {
        public string Id { get; set; }
        public string Truck_Name { get; set; }
        public string Price { get; set; }
        public decimal Rating { get; set; }
        public string Phone_Number { get; set; }
        public string[] Categories { get; set; }
        public GetCoordinatesModel Coordinates { get; set; }
        public string Location { get; set; }
    }
}
