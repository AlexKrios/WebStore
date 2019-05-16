namespace WebStoreAPI.Requests.OrderItems
{
    public class CreateOrderItemsRequest
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}