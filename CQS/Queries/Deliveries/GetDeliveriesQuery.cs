using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using LinqSpecs;

namespace CQS.Queries.Deliveries
{
    public class GetDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Specification<Delivery> Specification { get; set; }
    }
}
