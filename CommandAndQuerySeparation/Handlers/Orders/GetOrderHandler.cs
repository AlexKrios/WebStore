using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Orders
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly WebStoreContext _context;

        public GetOrderHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Orders.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
