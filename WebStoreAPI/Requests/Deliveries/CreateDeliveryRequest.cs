namespace WebStoreAPI.Requests.Deliveries
{
    public class CreateDeliveryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}
