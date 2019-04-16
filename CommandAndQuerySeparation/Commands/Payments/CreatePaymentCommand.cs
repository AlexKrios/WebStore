using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Payments
{
    public class CreatePaymentCommand : IRequest<Payment>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
