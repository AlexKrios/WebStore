using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Payments;
using DataLibrary.Entities;
using MediatR;

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
