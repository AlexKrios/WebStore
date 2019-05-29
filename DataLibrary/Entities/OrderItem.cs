﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    //DTO model OrderItem
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        [Required, Range(0, double.MaxValue), Column(TypeName = "decimal")]
        public decimal Price { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required, ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
