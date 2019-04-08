using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Availability { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Required, ForeignKey("Type")]
        public int TypeId { get; set; }
        [Required, ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public DateTime ModifiedDateTime { get; set; }

        public virtual Type Type { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
