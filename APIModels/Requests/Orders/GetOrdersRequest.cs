namespace APIModels.Requests.Orders
{
    public class GetOrdersRequest
    {
        public decimal? MinTotalPrice { get; set; }
        public decimal? MaxTotalPrice { get; set; }
        public int? UserId { get; set; }
        public int? DeliveryId { get; set; }
        public int? PaymentId { get; set; }
    }
}
