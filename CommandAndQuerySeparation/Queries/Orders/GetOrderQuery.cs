using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetOrderQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
