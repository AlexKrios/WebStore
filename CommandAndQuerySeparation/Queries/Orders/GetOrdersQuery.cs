using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {

    }
}
