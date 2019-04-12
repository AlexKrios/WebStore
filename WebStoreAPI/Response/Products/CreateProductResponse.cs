namespace WebStoreAPI.Response.Products
{
    public class CreateProductResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public decimal Price { get; set; }
    }
}
