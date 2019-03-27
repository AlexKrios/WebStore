using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get all products handler
    public class GetAllProductsHandler : IQueryHandler<GetAllProductsCommand, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetAllProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Execute(GetAllProductsCommand command)
        {
            return _context.Products;
        }
    }
}
