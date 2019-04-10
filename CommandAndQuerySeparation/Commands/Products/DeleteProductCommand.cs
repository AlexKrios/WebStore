using MediatR;

namespace CommandAndQuerySeparation.Commands.Products
{
    public class DeleteProductCommand : IRequest<DeleteProductCommand>
    {
        public int Id { get; set; }
    }
}
