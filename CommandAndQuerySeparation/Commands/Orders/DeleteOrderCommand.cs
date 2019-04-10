using MediatR;

namespace CommandAndQuerySeparation.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<DeleteOrderCommand>
    {
        public int Id { get; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
