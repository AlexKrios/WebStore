using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetPaymentQuery : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}
