using System.Collections.Generic;
using WebStoreAPI.Models;
using WebStoreAPI.Queries.Users;

namespace WebStoreAPI.Queries.Products
{
    //Query for output all products in table
    public class GetAllProductsHandler : GetAllUsers<IEnumerable<Product>>
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
