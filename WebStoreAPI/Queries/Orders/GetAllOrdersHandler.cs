using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly WebStoreContext _context;

        public GetAllOrdersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery command, CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }
    }
}