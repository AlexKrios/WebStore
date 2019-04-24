namespace APIModels.Requests.OrderItems
{
    public class CreateOrderItemsRequest
    {
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}