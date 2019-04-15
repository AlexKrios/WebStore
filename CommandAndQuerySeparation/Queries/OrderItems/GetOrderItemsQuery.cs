using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetOrderItemsQuery : IRequest<OrderItem>
    {
        public int Id { get; set; }
    }
}
