using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.OrderItems
{
    public class GetOrdersItemsQuery : IRequest<IEnumerable<OrderItem>>
    {

    }
}
