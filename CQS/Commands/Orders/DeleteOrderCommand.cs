using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
