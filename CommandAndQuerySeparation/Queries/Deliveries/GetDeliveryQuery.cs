using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Deliveries
{
    public class GetDeliveryQuery : IRequest<Delivery>
    {
        public int Id { get; set; }
    }
}
