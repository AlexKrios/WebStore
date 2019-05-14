using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Products
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
