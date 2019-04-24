using System;
using System.Collections.Generic;
using System.Linq;
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
                var result = _context.OrderItems.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (query.Filter.Filter.MinCount != null && query.Filter.Filter.MaxCount != null &&
                    query.Filter.Filter.MinPrice != null && query.Filter.Filter.MaxPrice != null &&
                    query.Filter.Filter.ProductId != null && query.Filter.Filter.OrderId != null)
                {
                    result = _context.OrderItems.Where(o => query.Filter.HasAll.IsSatisfiedBy(o));
                }

                if (!result.Any())
                {
                    return await _context.OrderItems.ToListAsync(cancellationToken);
                }

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