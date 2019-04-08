using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Deliveries
{
    public class GetDeliveryByIdHandler : IRequestHandler<GetDeliveryByIdQuery, Delivery>
    {
        private readonly WebStoreContext _context;

        public GetDeliveryByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Delivery> Handle(GetDeliveryByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
