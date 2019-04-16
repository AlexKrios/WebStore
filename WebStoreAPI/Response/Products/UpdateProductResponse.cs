namespace WebStoreAPI.Response.Products
{
    public class UpdateProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }
    }
}
