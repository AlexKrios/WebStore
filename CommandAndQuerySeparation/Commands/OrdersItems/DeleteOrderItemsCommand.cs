using MediatR;

namespace CQS.Commands.OrdersItems
{
    public class DeleteOrderItemsCommand : IRequest<DataLibrary.Entities.OrderItems>
    {
        public int Id { get; set; }
    }
}
