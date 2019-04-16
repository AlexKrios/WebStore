namespace WebStoreAPI.Requests.OrderItems
{
    public class GetOrdersItemsRequest
    {
        public int? MinCount { get; set; }
        public int? MaxCount { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
    }
}
