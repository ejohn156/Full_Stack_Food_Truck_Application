using System;
using System.ComponentModel.DataAnnotations;

namespace Full_Stack_Food_Truck_Application.Models.CategoryModels
{
    public class CreateCategoryModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        [Required]
        public string Favorite_Id { get; set; }
    }
}
