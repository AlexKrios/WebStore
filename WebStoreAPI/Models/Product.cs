using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreAPI.Models
{
    //Model for object product
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
        [Required]
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        [Required]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
    }
}
