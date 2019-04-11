using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly WebStoreContext _context;

        public GetOrderByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
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
