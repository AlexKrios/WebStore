using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.OrdersItems;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.OrdersItems
{
    public class GetOrdersItemsHandler : IRequestHandler<GetOrdersItemsQuery, IEnumerable<DataLibrary.Entities.OrderItems>>
    {
        private readonly WebStoreContext _context;

        public GetOrdersItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DataLibrary.Entities.OrderItems>> Handle(GetOrdersItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.OrdersItems.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}