using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Orders
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {
        public Specification<Order> Specification { get; set; }
    }
}
