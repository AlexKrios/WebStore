using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetOrderItemsByIdQuery : IRequest<OrderItem>
    {
        public int Id { get; set; }
    }
}
