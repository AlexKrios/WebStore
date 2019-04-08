using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.OrderItems
{
    public class GetOrderItemsByIdHandler : IRequestHandler<GetOrderItemsByIdQuery, OrderItem>
    {
        private readonly WebStoreContext _context;

        public GetOrderItemsByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Handle(GetOrderItemsByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
