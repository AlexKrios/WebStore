using System.Collections.Generic;
using APIModels.Filters;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        public GetProductsFilter Filter { get; set; }
    }
}