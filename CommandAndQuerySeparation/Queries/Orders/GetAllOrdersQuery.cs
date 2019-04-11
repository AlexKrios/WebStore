using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {

    }
}
