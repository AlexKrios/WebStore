using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Products;
using CQS.Specification;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                ISpecification<Product> samsungExpSpec =
                    new ExpressionSpecification<Product>(o => o.Name == "Samsung S7");

                var samsungMobiles = _context.Products.Find(o => samsungExpSpec.IsSatisfiedBy(o));

                return await _context.Products.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}