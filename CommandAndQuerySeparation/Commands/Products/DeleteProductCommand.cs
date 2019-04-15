using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Products
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
