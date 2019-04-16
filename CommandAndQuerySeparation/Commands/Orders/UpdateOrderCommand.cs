﻿using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Orders
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
        public int Count { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
    }
}
