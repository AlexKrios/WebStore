using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.OrderItems;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.OrderItems
{
    public class GetOrdersItemsHandler : IRequestHandler<GetOrdersItemsQuery, IEnumerable<OrderItem>>
    {
        private readonly WebStoreContext _context;

        public GetOrdersItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> Handle(GetOrdersItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.OrderItems.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}