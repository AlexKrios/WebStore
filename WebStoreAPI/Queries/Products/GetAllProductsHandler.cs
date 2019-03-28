using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get all products handler
    public class GetAllProductsHandler : Controller, IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetAllProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                NotFound();
            }

            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
