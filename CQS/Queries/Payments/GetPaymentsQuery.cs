using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Payments
{
    public class GetPaymentsQuery : IRequest<IEnumerable<Payment>>
    {
        public Specification<Payment> Specification { get; set; }
    }
}
