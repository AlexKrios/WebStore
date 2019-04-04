using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get single product command
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
