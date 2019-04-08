using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Payments
{
    public class GetPaymentByIdQuery : IRequest<Payment>
    {
        public int Id { get; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
