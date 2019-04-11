using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
