using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Orders
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
