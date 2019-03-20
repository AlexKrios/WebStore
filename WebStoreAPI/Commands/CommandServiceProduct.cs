using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    //Processing command request for product
    public class CommandServiceProduct : ICommandService<Product>
    {
        private readonly WebStoreContext _db;
        public CommandServiceProduct(WebStoreContext db)
        {
            _db = db;
        }
        public void Post(Product product)
        {
            _db.Products.Add(product);
        }
        public void Put(Product product)
        {
            _db.Update(product);
        }
        public void Delete(Product product)
        {
            _db.Products.Remove(product);
        }
        public void SaveDb()
        {
            _db.SaveChanges();
        }
    }
}
