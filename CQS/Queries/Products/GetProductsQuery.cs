using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Specification<Product> Specification { get; set; }
    }
}