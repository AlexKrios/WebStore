using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class DeleteOrderItemsCommand : IRequest<OrderItem>
    {
        public int Id { get; set; }
    }
}
