using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.OrdersItems;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.OrdersItems
{
    public class GetOrderItemsHandler : IRequestHandler<GetOrderItemsQuery, DataLibrary.Entities.OrderItems>
    {
        private readonly WebStoreContext _context;

        public GetOrderItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DataLibrary.Entities.OrderItems> Handle(GetOrderItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.OrdersItems.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
