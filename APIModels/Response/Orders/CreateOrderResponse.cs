namespace APIModels.Response.Orders
{
    public class CreateOrderResponse
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
    }
}
