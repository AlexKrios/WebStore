using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.OrderItems
{
    public class GetOrderItemsQuery : IRequest<OrderItem>
    {
        public int Id { get; set; }
    }
}
