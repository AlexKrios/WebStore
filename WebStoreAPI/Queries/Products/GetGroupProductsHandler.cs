using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Query for output group of product
    public class GetGroupProductsHandler : GetGroupProducts<IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;
        public GetGroupProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override IEnumerable<Product> Execute(string type)
        {
            IEnumerable<Product> products = _context.Products.Where(x => Equals(x.Type, type));
            return products.ToList();
        }
    }
}
