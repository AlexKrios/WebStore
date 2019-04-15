using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Orders
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string CustomerNumber { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
    }
}
