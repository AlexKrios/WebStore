using System.Collections.Generic;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get group of products command
    public class GetProductsByTypeQuery : IRequest<IEnumerable<Product>>
    {
        public string Type { get; }

        public GetProductsByTypeQuery(string type)
        {
            Type = type;
        }
    }
}
