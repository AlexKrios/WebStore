using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Taxes { get; set; }

        [Required, Column(TypeName = "datetime2")]
        public DateTime CreatedDateTime { get; set; }
        [Required, Column(TypeName = "datetime2")]
        public DateTime ModifiedDateTime { get; set; }
        [Required, ForeignKey("User")]
        public int ModifiedBy { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
