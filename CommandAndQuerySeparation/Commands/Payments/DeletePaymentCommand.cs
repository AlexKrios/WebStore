using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Payments
{
    public class DeletePaymentCommand : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}
