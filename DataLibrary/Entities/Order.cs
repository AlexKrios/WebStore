﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Entities
{
    //DTO model Order
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerNumber { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required, Column(TypeName = "datetime2")]
        public DateTime OrderTime { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required, ForeignKey("Delivery")]
        public int DeliveryId { get; set; }
        [Required, ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public virtual User User { get; set; }       
        public virtual Delivery Delivery { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
