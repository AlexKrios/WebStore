using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.OrderItems
{
    public class DeleteOrderItemsCommand : IRequest<OrderItem>
    {
        public int Id { get; set; }
    }
}
