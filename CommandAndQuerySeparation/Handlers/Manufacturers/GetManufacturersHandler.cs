using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Manufacturers
{
    public class GetManufacturersHandler : IRequestHandler<GetManufacturersQuery, IEnumerable<Manufacturer>>
    {
        private readonly WebStoreContext _context;

        public GetManufacturersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Manufacturer>> Handle(GetManufacturersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Manufacturers as IEnumerable<Manufacturer>;

                if (query.Filter.Request.MinRating.HasValue)
                {
                    list = _context.Manufacturers.Where(o => query.Filter.MinRating.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MaxRating.HasValue)
                {
                    list = _context.Manufacturers.Where(o => query.Filter.MaxRating.IsSatisfiedBy(o));
                }

                if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                {
                    list = _context.Manufacturers.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                }

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