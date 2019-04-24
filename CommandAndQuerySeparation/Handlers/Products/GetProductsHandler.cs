using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Products;
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
                var result = _context.Products.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (query.Filter.Filter.MinAvailability != null && query.Filter.Filter.MaxAvailability != null &&
                    query.Filter.Filter.MinPrice != null && query.Filter.Filter.MaxPrice != null &&
                    query.Filter.Filter.TypeId != null && query.Filter.Filter.ManufacturerId != null)
                {
                    result = _context.Products.Where(o => query.Filter.HasAll.IsSatisfiedBy(o));
                }

                if (!result.Any())
                {
                    return await _context.Products.ToListAsync(cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}