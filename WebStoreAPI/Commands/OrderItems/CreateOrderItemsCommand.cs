using MediatR;

namespace WebStoreAPI.Commands.OrderItems
{
    public class CreateOrderItemsCommand : IRequest<CreateOrderItemsCommand>
    {
        public string CustomerNumber { get; set; }
        public int Count { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
    }
}
