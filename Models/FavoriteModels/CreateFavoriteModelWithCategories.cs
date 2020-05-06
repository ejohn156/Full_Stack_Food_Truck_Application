using System;
namespace Full_Stack_Food_Truck_Application.Models.FavoriteModels
{
    public class CreateFavoriteModelWithCategories
    {
        public string Truck_Name { get; set; }
        public string Truck_Id { get; set; }
        public string Price { get; set; }
        public decimal Rating { get; set; }
        public string Phone_Number { get; set; }
        public string[] Categories { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Location { get; set; }
        public string Creator_Id { get; set; }
    }
}
