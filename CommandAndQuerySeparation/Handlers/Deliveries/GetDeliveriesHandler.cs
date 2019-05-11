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
                return await _context.Deliveries.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}