using MediatR;

namespace WebStoreAPI.Commands.OrderItems
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
