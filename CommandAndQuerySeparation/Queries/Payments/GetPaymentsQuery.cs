using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Payments;
using Specification.Specification.Filters;

namespace CQS.Queries.Payments
{
    public class GetPaymentsQuery : IRequest<IEnumerable<Payment>>
    {
        public GetPaymentsFilter Filter { get; set; }

        public GetPaymentsQuery(GetPaymentsRequest filter)
        {
            Filter = new GetPaymentsFilter(filter);
        }
    }
}
