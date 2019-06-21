namespace WebStoreAPI.Requests.Manufacturers
{
    public class GetManufacturersRequest
    {
        public string Name { get; set; }
        public float? MinRating { get; set; }
        public float? MaxRating { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
