using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetOrderItemsByIdQuery : IRequest<GetOrderItemsByIdQuery>
    {
        public int Id { get; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public GetOrderItemsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
