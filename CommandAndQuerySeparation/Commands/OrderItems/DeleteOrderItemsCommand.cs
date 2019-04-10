using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class DeleteOrderItemsCommand : IRequest<DeleteOrderItemsCommand>
    {
        public int Id { get; }

        public DeleteOrderItemsCommand(int id)
        {
            Id = id;
        }
    }
}
