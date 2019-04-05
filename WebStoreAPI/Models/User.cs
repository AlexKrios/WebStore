using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreAPI.Models
{
    //Model for object user
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public DateTime RegistrationTime { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
    }
}
