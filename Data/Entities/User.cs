using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Full_Stack_Food_Truck_Application.Data.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}
