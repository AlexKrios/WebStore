using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly WebStoreContext _context;

        public GetAllPaymentsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query, CancellationToken cancellationToken)
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