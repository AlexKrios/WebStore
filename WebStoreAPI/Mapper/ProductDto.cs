using System.ComponentModel.DataAnnotations;

namespace WebStoreAPI.Mapper
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
        public int Price { get; set; }
    }
}
