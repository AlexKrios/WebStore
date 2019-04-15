using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetDeliveryQuery : IRequest<Delivery>
    {
        public int Id { get; set; }
    }
}
