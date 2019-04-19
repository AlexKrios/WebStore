using System.Collections.Generic;
using CQS.Requests.Products;
using CQS.Specification;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        public GetProductsRequest Filter { get; set; }

        public ISpecification<Product> HasName =
            new ExpressionSpecification<Product>(o => o.Name.Equals("Samsung S7"));

        public ISpecification<Product> MinPrice =
            new ExpressionSpecification<Product>(o => o.Price > Filter.MinPrice);
        public ISpecification<Product> MaxPrice =
            new ExpressionSpecification<Product>(o => o.Price < 500);
    }
}