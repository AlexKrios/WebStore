using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.OrderItems
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItem>>
    {
    }
}
