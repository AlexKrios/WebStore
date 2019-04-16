using System;

namespace WebStoreAPI.Requests.Orders
{
    public class GetOrderRequest
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
    }
}
