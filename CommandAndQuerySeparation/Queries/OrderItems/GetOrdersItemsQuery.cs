using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.OrderItems;
using DataLibrary.Entities;
using MediatR;

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
