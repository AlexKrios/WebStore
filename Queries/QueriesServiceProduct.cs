using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries
{
    //Querie class for Product
    public class QueriesServiceProduct : IQueriesService<Product>
    {
        private readonly WebStoreContext context;
        public QueriesServiceProduct(WebStoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }
        public Product GetSingle(int id)
        {
            Product product = context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
        public IEnumerable<Product> GetGroup(string str)
        {
            IEnumerable<Product> products = context.Products.Where(x => x.Type == str);
            return products.ToList();
        }
    }
}
