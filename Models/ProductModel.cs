namespace WebStoreAPI.Models
{
    //Processing command request for product
    public class ProductModel
    {
        public void Post(WebStoreContext db, Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void Put(WebStoreContext db, Product product)
        {
            db.Update(product);
            db.SaveChanges();
        }
        public void Delete (WebStoreContext db, Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }

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


