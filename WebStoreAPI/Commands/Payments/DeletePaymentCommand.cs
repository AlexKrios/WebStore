using MediatR;

namespace WebStoreAPI.Commands.Payments
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
