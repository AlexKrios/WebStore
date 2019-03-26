using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    public class GetGroupProductsHandler : Query<IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;
        public GetGroupProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override IEnumerable<Product> Execute(string type)
        {
            IEnumerable<Product> products = _context.Products.Where(x => x.Type == type);
            return products.ToList();
        }
    }
}
