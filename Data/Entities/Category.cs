using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Full_Stack_Food_Truck_Application.Data.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public string Favorite_Id { get; set; }
        [ForeignKey("Favorite_Id")]
        public Favorite Favorite { get; set; }
    }
}
