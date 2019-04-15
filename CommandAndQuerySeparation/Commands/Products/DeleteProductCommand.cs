using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Products
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
