using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
