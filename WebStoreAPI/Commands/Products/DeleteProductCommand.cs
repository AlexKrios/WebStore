using MediatR;

namespace WebStoreAPI.Commands.Products
{
    //Delete request command for product
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
