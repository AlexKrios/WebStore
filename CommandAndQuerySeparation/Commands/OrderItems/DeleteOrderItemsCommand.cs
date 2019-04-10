using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class DeleteOrderItemsCommand : IRequest<DeleteOrderItemsCommand>
    {
        public int Id { get; set; }
    }
}
