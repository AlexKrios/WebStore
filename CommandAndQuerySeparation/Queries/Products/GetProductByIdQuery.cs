using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
