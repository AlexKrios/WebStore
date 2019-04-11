using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetOrderItemsByIdHandler : IRequestHandler<GetOrderItemsByIdQuery, OrderItem>
    {
        private readonly WebStoreContext _context;

        public GetOrderItemsByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Handle(GetOrderItemsByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
