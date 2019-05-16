using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.OrderItems
{
    public class GetOrdersItemsQuery : IRequest<IEnumerable<OrderItem>>
    {
        public Specification<OrderItem> Specification { get; set; }
    }
}
