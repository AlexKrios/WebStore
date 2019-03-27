using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get group of products handler
    public class GetGroupProductsHandler : IQueryHandler<GetGroupProductsQueries, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetGroupProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Execute(GetGroupProductsQueries command)
        {
            return await _context.Products.Where(x => Equals(x.Type, command.Type)).ToListAsync();
        }
    }
}
