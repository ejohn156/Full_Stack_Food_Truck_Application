using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Full_Stack_Food_Truck_Application.Data.Entities
{
    public class Favorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Truck_Name { get; set; }
        public string Price { get; set; }
        public decimal Rating { get; set; }
        public string Phone_Number { get; set; }
        public string[] Categories { get; set; }
        public string Coordinate_Id { get; set; }
        [ForeignKey("Coordinate_Id")]
        public Coordinates Coordinates { get; set; }
        public string Location { get; set; }
        public string Creator_Id { get; set; }
        [ForeignKey("Creator_Id")]
        public User CreatedBy { get; set; }
    }
}
