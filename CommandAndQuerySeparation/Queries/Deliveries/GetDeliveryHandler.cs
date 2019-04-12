using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetDeliveryHandler : IRequestHandler<GetDeliveryQuery, Delivery>
    {
        private readonly WebStoreContext _context;

        public GetDeliveryHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Delivery> Handle(GetDeliveryQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
