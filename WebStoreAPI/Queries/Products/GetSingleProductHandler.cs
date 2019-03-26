using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Query for output single product
    public class GetSingleProductHandler : GetSingleProduct<Product>
    {
        private readonly WebStoreContext _context;
        public GetSingleProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override Product Execute(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
