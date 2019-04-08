using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.OrderItems
{
    public class GetAllOrderItemsHandler : IRequestHandler<GetAllOrderItemsQuery, IEnumerable<OrderItem>>
    {
        private readonly WebStoreContext _context;

        public GetAllOrderItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> Handle(GetAllOrderItemsQuery command, CancellationToken cancellationToken)
        {
            return await _context.OrderItems.ToListAsync(cancellationToken);
        }
    }
}