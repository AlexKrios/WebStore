using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStoreAPI.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string CustomerNumber { get; set; }
        [Required]
        public int Count { get; set; }
        public string Note { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required]
        [ForeignKey("Delivery")]
        public Guid DeliveryId { get; set; }
        [Required]
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
    }
}
