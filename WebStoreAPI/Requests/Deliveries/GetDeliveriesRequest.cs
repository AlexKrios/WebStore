namespace WebStoreAPI.Requests.Deliveries
{
    public class GetDeliveriesRequest
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public float? MinRating { get; set; }
        public float? MaxRating { get; set; }
    }
}
