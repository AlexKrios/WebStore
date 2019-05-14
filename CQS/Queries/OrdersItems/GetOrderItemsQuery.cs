using MediatR;

namespace CQS.Queries.OrdersItems
{
    public class GetOrderItemsQuery : IRequest<DataLibrary.Entities.OrderItems>
    {
        public int Id { get; set; }
    }
}
