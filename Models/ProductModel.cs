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
}


