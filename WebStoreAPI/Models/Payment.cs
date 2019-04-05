using System;
using System.ComponentModel.DataAnnotations;

namespace WebStoreAPI.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Taxes { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public DateTime ModifiedDateTime { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
    }
}
