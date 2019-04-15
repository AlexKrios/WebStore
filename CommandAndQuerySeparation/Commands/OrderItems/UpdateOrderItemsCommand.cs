using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class UpdateOrderItemsCommand : IRequest<OrderItem>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
