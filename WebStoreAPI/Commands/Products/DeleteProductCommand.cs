using MediatR;

namespace WebStoreAPI.Commands.Products
{
    public class DeleteProductCommand : IRequest<DeleteProductCommand>
    {
        public int Id { get; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
