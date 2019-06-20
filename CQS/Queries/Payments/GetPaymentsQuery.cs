using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Payments
{
    public class GetPaymentsQuery : IRequest<IEnumerable<Payment>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Specification<Payment> Specification { get; set; }
    }
}
