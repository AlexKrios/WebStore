using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Payments;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Payments
{
    public class GetPaymentsHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly WebStoreContext _context;

        public GetPaymentsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Payment>> Handle(GetPaymentsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Payments as IEnumerable<Payment>;

                //if (query.Filter.Request.MinTaxes.HasValue)
                //{
                //    list = _context.Payments.Where(o => query.Filter.MinTaxes.IsSatisfiedBy(o));
                //}

                //if (query.Filter.Request.MaxTaxes.HasValue)
                //{
                //    list = _context.Payments.Where(o => query.Filter.MaxTaxes.IsSatisfiedBy(o));
                //}

                //if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                //{
                //    list = _context.Payments.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                //}

                return Task.FromResult(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}