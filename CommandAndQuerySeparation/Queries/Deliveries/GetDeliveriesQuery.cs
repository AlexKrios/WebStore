using System.Collections.Generic;
using APIModels.Filters;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Deliveries
{
    public class GetDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
        public GetDeliveriesFilter Filter { get; set; }
    }
}
