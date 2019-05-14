using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Payments
{
    public class UpdatePaymentCommand : IRequest<Payment>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
