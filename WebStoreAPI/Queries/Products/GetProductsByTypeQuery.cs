using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Products
{
    public class GetProductsByTypeQuery : IRequest<IEnumerable<Product>>
    {
        public string Type { get; }

        public GetProductsByTypeQuery(string type)
        {
            Type = type;
        }
    }
}
