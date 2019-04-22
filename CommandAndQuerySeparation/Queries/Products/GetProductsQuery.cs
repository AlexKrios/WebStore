using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Products;
using Specification.Specification.Filters;

namespace CQS.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        public GetProductsFilter Filter { get; set; }

        public GetProductsQuery(GetProductsRequest filter)
        {
            Filter = new GetProductsFilter(filter);
        }
    }
}