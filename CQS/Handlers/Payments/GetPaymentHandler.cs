using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Payments;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Payments
{
    public class GetPaymentHandler : IRequestHandler<GetPaymentQuery, Payment>
    {
        private readonly WebStoreContext _context;

        public GetPaymentHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Payment> Handle(GetPaymentQuery query, CancellationToken cancellationToken)
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
