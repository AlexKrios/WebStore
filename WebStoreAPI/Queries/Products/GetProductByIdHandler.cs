using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get single product handler
    public class GetProductByIdHandler : Controller, IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly WebStoreContext _context;

        public GetProductByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (product == null)
            {
                NotFound();
            }

            return product;
        }
    }
}
