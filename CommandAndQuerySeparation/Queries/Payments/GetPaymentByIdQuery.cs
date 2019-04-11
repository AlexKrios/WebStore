using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetPaymentByIdQuery : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}
