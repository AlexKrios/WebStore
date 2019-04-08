using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Payments
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, Payment>
    {
        private readonly WebStoreContext _context;

        public GetPaymentByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Payment> Handle(GetPaymentByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
