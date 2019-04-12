using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
