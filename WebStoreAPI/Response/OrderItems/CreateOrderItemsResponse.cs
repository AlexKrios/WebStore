namespace WebStoreAPI.Response.OrderItems
{
    public class CreateOrderItemsResponse
    {
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
