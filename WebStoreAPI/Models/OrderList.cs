using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreAPI.Models
{
    public class OrderList
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
    }
}
