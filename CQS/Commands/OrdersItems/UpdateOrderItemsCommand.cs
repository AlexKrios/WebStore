using MediatR;

namespace CQS.Commands.OrdersItems
{
    public class UpdateOrderItemsCommand : IRequest<DataLibrary.Entities.OrderItems>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
