using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get single product command
    public class GetSingleProductQuery : IRequest<Product>
    {
        public int Id { get; }

        public GetSingleProductQuery(int id)
        {
            Id = id;
        }
    }
}
