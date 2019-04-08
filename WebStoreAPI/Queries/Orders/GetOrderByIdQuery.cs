using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
