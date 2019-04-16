using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.OrderItems
{
    public class CreateOrderItemsCommand : IRequest<OrderItem>
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
