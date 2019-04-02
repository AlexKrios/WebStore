using System.ComponentModel.DataAnnotations;

namespace WebStoreAPI.Models
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
