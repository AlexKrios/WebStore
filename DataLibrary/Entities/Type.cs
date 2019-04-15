using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities
{
    //DTO model Type
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}