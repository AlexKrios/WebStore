using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, Payment>
    {
        private readonly WebStoreContext _context;

        public GetPaymentByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Payment> Handle(GetPaymentByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Payments.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
