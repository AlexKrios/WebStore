using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    //Processing command request for product
    public class CommandServiceProduct : ICommandService<Product>
    {
        private readonly WebStoreContext db;
        public CommandServiceProduct(WebStoreContext db)
        {
            this.db = db;
        }
        public void Post(Product product)
        {
            db.Products.Add(product);
        }
        public void Put(Product product)
        {
            db.Update(product);
        }
        public void Delete(Product product)
        {
            db.Products.Remove(product);
        }
        public void SaveDB()
        {
            db.SaveChanges();
        }
    }
}
