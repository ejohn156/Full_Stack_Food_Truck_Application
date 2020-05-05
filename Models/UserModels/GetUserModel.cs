using System;
using System.Collections.Generic;
using Full_Stack_Food_Truck_Application.Data.Entities;

namespace Full_Stack_Food_Truck_Application.Models.UserModels
{
    public class GetUserModel
    {
        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Favorite> Favorites { get; set; }
    }
}
