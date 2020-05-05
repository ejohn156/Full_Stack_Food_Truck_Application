using System;
using System.ComponentModel.DataAnnotations;

namespace Full_Stack_Food_Truck_Application.Models.UserModels
{
    public class AuthenticateUserModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
