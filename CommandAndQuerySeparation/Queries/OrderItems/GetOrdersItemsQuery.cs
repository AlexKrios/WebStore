using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.OrderItems;
using Specification.Specification.Filters;

namespace CQS.Queries.OrderItems
{
    public class GetOrdersItemsQuery : IRequest<IEnumerable<OrderItem>>
    {
        public GetOrdersItemsFilter Filter { get; set; }

        public GetOrdersItemsQuery(GetOrdersItemsRequest filter)
        {
            Filter = new GetOrdersItemsFilter(filter);
        }
    }
}
