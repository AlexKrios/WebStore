using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    //DTO model User
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required, Column(TypeName = "datetime2")]
        public DateTime RegistrationTime { get; set; }
        [Required]
        public string Address { get; set; }

        [Required, ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
