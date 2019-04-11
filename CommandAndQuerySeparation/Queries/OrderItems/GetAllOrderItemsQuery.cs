using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItem>>
    {

    }
}
