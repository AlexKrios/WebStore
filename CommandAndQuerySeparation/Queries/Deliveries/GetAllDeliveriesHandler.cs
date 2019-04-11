using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetAllDeliveriesHandler : IRequestHandler<GetAllDeliveriesQuery, IEnumerable<Delivery>>
    {
        private readonly WebStoreContext _context;

        public GetAllDeliveriesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> Handle(GetAllDeliveriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Deliveries.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}