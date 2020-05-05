using System;
using System.ComponentModel.DataAnnotations;

namespace Full_Stack_Food_Truck_Application.Models.UserModels
{
    public class CreateUserModel
    {
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
