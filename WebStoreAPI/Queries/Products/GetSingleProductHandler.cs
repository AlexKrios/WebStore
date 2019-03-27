using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get single product handler
    public class GetSingleProductHandler : IQueryHandler<GetSingleProductCommand, Product>
    {
        private readonly WebStoreContext _context;

        public GetSingleProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Product Execute(GetSingleProductCommand command)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == command.Id);
            return product;
        }
    }
}
