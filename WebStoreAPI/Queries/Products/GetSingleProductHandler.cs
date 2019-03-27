using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get single product handler
    public class GetSingleProductHandler : IQueryHandler<GetSingleProductQueries, Product>
    {
        private readonly WebStoreContext _context;

        public GetSingleProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Execute(GetSingleProductQueries command)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == command.Id);
        }
    }
}
