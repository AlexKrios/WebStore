using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetDeliveryByIdQuery : IRequest<Delivery>
    {
        public int Id { get; set; }
    }
}
