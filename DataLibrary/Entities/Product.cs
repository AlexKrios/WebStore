using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    //DTO model Product
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

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }
        [ForeignKey("User")]
        public int ModifiedBy { get; set; }

        public virtual Type Type { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }

    }
}
