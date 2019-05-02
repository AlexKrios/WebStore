using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Deliveries
{
    public class GetDeliveriesHandler : IRequestHandler<GetDeliveriesQuery, IEnumerable<Delivery>>
    {
        private readonly WebStoreContext _context;

        public GetDeliveriesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Delivery>> Handle(GetDeliveriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Deliveries as IEnumerable<Delivery>;

                if (query.Filter.Request.MinPrice.HasValue)
                {
                    list = _context.Deliveries.Where(o => query.Filter.MinPrice.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MaxPrice.HasValue)
                {
                    list = _context.Deliveries.Where(o => query.Filter.MaxPrice.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MinRating.HasValue)
                {
                    list = _context.Deliveries.Where(o => query.Filter.MinRating.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MaxRating.HasValue)
                {
                    list = _context.Deliveries.Where(o => query.Filter.MaxRating.IsSatisfiedBy(o));
                }

                if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                {
                    list = _context.Deliveries.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
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