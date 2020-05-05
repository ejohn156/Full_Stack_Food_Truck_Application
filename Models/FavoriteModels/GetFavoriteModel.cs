using System;
using Full_Stack_Food_Truck_Application.Data.Entities;

namespace Full_Stack_Food_Truck_Application.Models.FavoriteModels
{
    public class GetFavoriteModel
    {
        public string Id { get; set; }
        public string Truck_Name { get; set; }
        public string Price { get; set; }
        public decimal Rating { get; set; }
        public string Phone_Number { get; set; }
        public string[] Categories { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Location { get; set; }
        public User CreatedBy { get; set; }
    }
}
