using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get group of products handler
    public class GetGroupProductsHandler : IQueryHandler<GetGroupProductsCommand, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetGroupProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Execute(GetGroupProductsCommand command)
        {
            IEnumerable<Product> products = _context.Products.Where(x => Equals(x.Type, command.Type));
            return products.ToList();
        }
    }
}
