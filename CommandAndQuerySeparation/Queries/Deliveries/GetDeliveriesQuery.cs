using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Deliveries;
using Specification.Specification.Filters;

namespace CQS.Queries.Deliveries
{
    public class GetDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
        public GetDeliveriesFilter Filter { get; set; }

        public GetDeliveriesQuery(GetDeliveriesRequest filter)
        {
            Filter = new GetDeliveriesFilter(filter);
        }
    }
}
