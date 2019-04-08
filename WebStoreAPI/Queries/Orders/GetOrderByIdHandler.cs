using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Orders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly WebStoreContext _context;

        public GetOrderByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
