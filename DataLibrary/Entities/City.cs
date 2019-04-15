using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    //DTO model City
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required, ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
