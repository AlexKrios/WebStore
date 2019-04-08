using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public float Rating { get; set; }
    }
}
