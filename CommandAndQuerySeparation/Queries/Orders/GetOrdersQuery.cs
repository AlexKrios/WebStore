using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Orders;
using DataLibrary.Entities;
using MediatR;

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
