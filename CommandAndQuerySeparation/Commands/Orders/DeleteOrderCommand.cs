using MediatR;

namespace CommandAndQuerySeparation.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<DeleteOrderCommand>
    {
        public int Id { get; set; }
    }
}
