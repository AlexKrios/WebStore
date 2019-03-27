namespace WebStoreAPI.Models
{
    //Model for object product
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Path { get; set; }
    }
}
