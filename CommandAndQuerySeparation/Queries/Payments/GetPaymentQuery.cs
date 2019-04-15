using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Payments
{
    public class GetPaymentQuery : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}
