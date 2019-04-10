using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class CreateOrderItemsCommand : IRequest<CreateOrderItemsCommand>
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
