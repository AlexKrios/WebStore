using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Orders
{
    public class GetOrderQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
