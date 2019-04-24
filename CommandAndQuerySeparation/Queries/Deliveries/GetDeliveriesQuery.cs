using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Deliveries;
using DataLibrary.Entities;
using MediatR;

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
