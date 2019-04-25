using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Cities
{
    public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IEnumerable<City>>
    {
        private readonly WebStoreContext _context;

        public GetCitiesHandler(WebStoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Cities.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (query.Filter.Filter.Name != null && query.Filter.Filter.CountryId != null)
                {
                    result = _context.Cities.Where(o => query.Filter.AllEquals.IsSatisfiedBy(o));
                }

                if (!result.Any())
                {
                    return await _context.Cities.ToListAsync(cancellationToken);
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