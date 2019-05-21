using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Payments
{
    public class DeletePaymentCommand : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}
