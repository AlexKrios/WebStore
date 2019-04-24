using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Manufacturers
{
    public class GetManufacturersHandler : IRequestHandler<GetManufacturersQuery, IEnumerable<Manufacturer>>
    {
        private readonly WebStoreContext _context;

        public GetManufacturersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manufacturer>> Handle(GetManufacturersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Manufacturers.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (query.Filter.Filter.MinRating != null && query.Filter.Filter.MaxRating != null &&
                    query.Filter.Filter.Name != null)
                {
                    result = _context.Manufacturers.Where(o => query.Filter.HasAll.IsSatisfiedBy(o));
                }

                if (!result.Any())
                {
                    return await _context.Manufacturers.ToListAsync(cancellationToken);
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