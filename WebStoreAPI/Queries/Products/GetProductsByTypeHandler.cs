using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get group of products handler
    public class GetProductsByTypeHandler : IRequestHandler<GetProductsByTypeQuery, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;
        private readonly IMediator _mediator;

        public GetProductsByTypeHandler(WebStoreContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery command, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(x => Equals(x.Type, command.Type)).ToListAsync(cancellationToken);
        }
    }
}
