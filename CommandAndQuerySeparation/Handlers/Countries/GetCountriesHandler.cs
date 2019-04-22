using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Countries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Countries
{
    public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IEnumerable<Country>>
    {
        private readonly WebStoreContext _context;

        public GetCountriesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Countries.Where(o => query.Filter.HasName.IsSatisfiedBy(o));
                if (!result.Any())
                    return await _context.Countries.ToListAsync(cancellationToken);
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