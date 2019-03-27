using System.Collections.Generic;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get group of products command
    public class GetGroupProductsQuery : IRequest<IEnumerable<Product>>
    {
        public string Type { get; }

        public GetGroupProductsQuery(string type)
        {
            Type = type;
        }
    }
}
