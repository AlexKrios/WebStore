using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
