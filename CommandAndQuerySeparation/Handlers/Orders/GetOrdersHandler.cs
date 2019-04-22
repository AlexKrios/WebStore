using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly WebStoreContext _context;

        public GetOrdersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Orders.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (!result.Any())
                    return await _context.Orders.ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}