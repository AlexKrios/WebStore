using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.OrderItems;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.OrderItems
{
    public class GetOrderItemsHandler : IRequestHandler<GetOrderItemsQuery, OrderItem>
    {
        private readonly WebStoreContext _context;

        public GetOrderItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Handle(GetOrderItemsQuery query, CancellationToken cancellationToken)
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
