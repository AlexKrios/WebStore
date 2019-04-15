namespace WebStoreAPI.Response.Products
{
    public class DeleteProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public decimal Price { get; set; }
    }
}
