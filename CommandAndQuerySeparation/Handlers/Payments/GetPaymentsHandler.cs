using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Payments;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Payments
{
    public class GetPaymentsHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly WebStoreContext _context;

        public GetPaymentsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> Handle(GetPaymentsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Payments.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}