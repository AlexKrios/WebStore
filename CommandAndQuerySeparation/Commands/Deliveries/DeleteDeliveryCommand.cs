using MediatR;

namespace CommandAndQuerySeparation.Commands.Deliveries
{
    public class DeleteDeliveryCommand : IRequest<DeleteDeliveryCommand>
    {
        public int Id { get; }

        public DeleteDeliveryCommand(int id)
        {
            Id = id;
        }
    }
}
