using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Products;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Products as IEnumerable<Product>;

                //if (query.Filter.Request.MinAvailability.HasValue)
                //{
                //    list = _context.Products.Where(o => query.Filter.MinAvailability.IsSatisfiedBy(o));
                //}

                //if (query.Filter.Request.MaxAvailability.HasValue)
                //{
                //    list = _context.Products.Where(o => query.Filter.MaxAvailability.IsSatisfiedBy(o));
                //}

                //if (query.Filter.Request.MinPrice.HasValue)
                //{
                //    list = _context.Products.Where(o => query.Filter.MinPrice.IsSatisfiedBy(o));
                //}

                //if (query.Filter.Request.MaxPrice.HasValue)
                //{
                //    list = _context.Products.Where(o => query.Filter.MaxPrice.IsSatisfiedBy(o));
                //}

                //if (query.Filter.Request.TypeId.HasValue)
                //{
                //    list = _context.Products.Where(o => query.Filter.TypeId.IsSatisfiedBy(o));
                //}

                //if (query.Filter.Request.ManufacturerId.HasValue)
                //{
                //    list = _context.Products.Where(o => query.Filter.ManufacturerId.IsSatisfiedBy(o));
                //}

                //if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                //{
                //    list = _context.Products.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                //}

                return Task.FromResult(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}