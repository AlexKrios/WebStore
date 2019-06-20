using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.OrderItems
{
    public class GetOrdersItemsQuery : IRequest<IEnumerable<OrderItem>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Specification<OrderItem> Specification { get; set; }
    }
}
