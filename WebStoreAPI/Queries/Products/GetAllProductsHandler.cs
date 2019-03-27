using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get all products handler
    public class GetAllProductsHandler : IQueryHandler<GetAllProductsQueries, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetAllProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Execute(GetAllProductsQueries command)
        {
            return await _context.Products.ToListAsync();
        }
    }
}
