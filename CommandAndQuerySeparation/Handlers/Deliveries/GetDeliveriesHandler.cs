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
                if (!query.Filter.Filter.MinPrice.HasValue &&
                    !query.Filter.Filter.MaxPrice.HasValue &&
                    !query.Filter.Filter.MinRating.HasValue &&
                    !query.Filter.Filter.MaxRating.HasValue &&
                    string.IsNullOrEmpty(query.Filter.Filter.Name))
                {
                    return await _context.Deliveries.ToListAsync(cancellationToken);
                }
                return await _context.Deliveries.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o)).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}