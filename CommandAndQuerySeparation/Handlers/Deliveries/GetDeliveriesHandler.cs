using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Deliveries
{
    public class GetDeliveriesHandler : IRequestHandler<GetDeliveriesQuery, IEnumerable<Delivery>>
    {
        private readonly WebStoreContext _context;

        public GetDeliveriesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> Handle(GetDeliveriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Deliveries.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (query.Filter.Filter.MinPrice != null && query.Filter.Filter.MaxPrice != null &&
                    query.Filter.Filter.MinRating != null && query.Filter.Filter.MaxRating != null &&
                    query.Filter.Filter.Name != null)
                {
                    result = _context.Deliveries.Where(o => query.Filter.AllEquals.IsSatisfiedBy(o));
                }

                if (!result.Any())
                {
                    return await _context.Deliveries.ToListAsync(cancellationToken);
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