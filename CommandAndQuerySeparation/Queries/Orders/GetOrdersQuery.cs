using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Orders;
using Specification.Specification.Filters;

namespace CQS.Queries.Orders
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {
        public GetOrdersFilter Filter { get; set; }

        public GetOrdersQuery(GetOrdersRequest filter)
        {
            Filter = new GetOrdersFilter(filter);
        }
    }
}
