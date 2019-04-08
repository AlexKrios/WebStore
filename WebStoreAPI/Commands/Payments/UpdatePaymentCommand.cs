using MediatR;

namespace WebStoreAPI.Commands.Payments
{
    public class UpdatePaymentCommand : IRequest<UpdatePaymentCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
