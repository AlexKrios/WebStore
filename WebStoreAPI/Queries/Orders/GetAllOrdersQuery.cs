using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
