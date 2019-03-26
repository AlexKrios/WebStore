using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    public class GetAllProductsHandler : Query<IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;
        public GetAllProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override IEnumerable<Product> Execute()
        {
            return _context.Products;
        }
    }
}
