using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Products;
using DataLibrary.Entities;
using MediatR;

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