using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using LinqSpecs;

namespace CQS.Queries.Deliveries
{
    public class GetDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
        public Specification<Delivery> Specification { get; set; }
    }
}
