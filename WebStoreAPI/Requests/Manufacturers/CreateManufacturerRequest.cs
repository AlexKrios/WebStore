namespace WebStoreAPI.Requests.Manufacturers
{
    public class CreateManufacturerRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Rating { get; set; }
    }
}
