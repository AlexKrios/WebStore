using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.OrderItems;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.OrderItems
{
    public class GetOrdersItemsHandler : IRequestHandler<GetOrdersItemsQuery, IEnumerable<OrderItem>>
    {
        private readonly WebStoreContext _context;

        public GetOrdersItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<OrderItem>> Handle(GetOrdersItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.OrderItems as IEnumerable<OrderItem>;

                if (query.Filter.Request.MinCount.HasValue)
                {
                    list = _context.OrderItems.Where(o => query.Filter.MinCount.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MaxCount.HasValue)
                {
                    list = _context.OrderItems.Where(o => query.Filter.MaxCount.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MinPrice.HasValue)
                {
                    list = _context.OrderItems.Where(o => query.Filter.MinPrice.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MaxPrice.HasValue)
                {
                    list = _context.OrderItems.Where(o => query.Filter.MaxPrice.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.ProductId.HasValue)
                {
                    list = _context.OrderItems.Where(o => query.Filter.ProductId.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.OrderId.HasValue)
                {
                    list = _context.OrderItems.Where(o => query.Filter.OrderId.IsSatisfiedBy(o));
                }

                return Task.FromResult(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}