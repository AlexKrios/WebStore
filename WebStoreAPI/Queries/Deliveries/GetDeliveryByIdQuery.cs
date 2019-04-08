using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Deliveries
{
    public class GetDeliveryByIdQuery : IRequest<Delivery>
    {
        public int Id { get; }

        public GetDeliveryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
