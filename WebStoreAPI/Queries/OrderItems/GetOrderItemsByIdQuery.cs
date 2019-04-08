using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.OrderItems
{
    public class GetOrderItemsByIdQuery : IRequest<OrderItem>
    {
        public int Id { get; }

        public GetOrderItemsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
