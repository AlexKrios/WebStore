using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<GetAllOrderItemsQuery>>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
