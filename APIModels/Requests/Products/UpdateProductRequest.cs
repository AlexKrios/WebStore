namespace APIModels.Requests.Products
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public decimal? Price { get; set; }
        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }
    }
}
