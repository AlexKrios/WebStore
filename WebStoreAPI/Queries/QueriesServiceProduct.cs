using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries
{
    //Querie class for Product
    public class QueriesServiceProduct : IQueriesService<Product>
    {
        private readonly WebStoreContext _context;
        public QueriesServiceProduct(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }
        public Product GetSingle(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
        public IEnumerable<Product> GetGroup(string str)
        {
            IEnumerable<Product> products = _context.Products.Where(x => x.Type == str);
            return products.ToList();
        }
    }
}
