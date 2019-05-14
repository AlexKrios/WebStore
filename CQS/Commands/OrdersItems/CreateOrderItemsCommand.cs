using MediatR;

namespace CQS.Commands.OrdersItems
{
    public class CreateOrderItemsCommand : IRequest<DataLibrary.Entities.OrderItems>
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
