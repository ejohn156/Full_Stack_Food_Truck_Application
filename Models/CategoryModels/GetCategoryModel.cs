using System;
namespace Full_Stack_Food_Truck_Application.Models.CategoryModels
{
    public class GetCategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public GetFavoriteOfCategoryModel Favorite { get; set; }
    }
}
