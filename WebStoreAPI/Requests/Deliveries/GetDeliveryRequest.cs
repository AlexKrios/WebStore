namespace WebStoreAPI.Requests.Deliveries
{
    public class GetDeliveryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}