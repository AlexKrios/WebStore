using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly WebStoreContext _context;

        public GetOrdersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Order>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Orders as IEnumerable<Order>;

                if (query.Filter.Request.MinTotalPrice.HasValue)
                {
                    list = _context.Orders.Where(o => query.Filter.MinTotalPrice.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MaxTotalPrice.HasValue)
                {
                    list = _context.Orders.Where(o => query.Filter.MaxTotalPrice.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.UserId.HasValue)
                {
                    list = _context.Orders.Where(o => query.Filter.UserId.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.DeliveryId.HasValue)
                {
                    list = _context.Orders.Where(o => query.Filter.DeliveryId.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.PaymentId.HasValue)
                {
                    list = _context.Orders.Where(o => query.Filter.PaymentId.IsSatisfiedBy(o));
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