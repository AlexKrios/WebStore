using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Entities
{
    //DTO model Country
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
