using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Full_Stack_Food_Truck_Application.Data.Entities
{
    public class Coordinates
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Truck_Id { get; set; }
    }
}
