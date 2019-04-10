using MediatR;

namespace CommandAndQuerySeparation.Commands.Payments
{
    public class DeletePaymentCommand : IRequest<DeletePaymentCommand>
    {
        public int Id { get; }

        public DeletePaymentCommand(int id)
        {
            Id = id;
        }
    }
}
