using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
