using System;
using System.Collections.Generic;
using System.Linq;
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
                var result = _context.Payments.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (query.Filter.Filter.MinTaxes != null && query.Filter.Filter.MaxTaxes != null &&
                    query.Filter.Filter.Name != null)
                {
                    result = _context.Payments.Where(o => query.Filter.AllEquals.IsSatisfiedBy(o));
                }

                if (!result.Any())
                    return await _context.Payments.ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}