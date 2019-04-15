using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Countries
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
                return await _context.Countries.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}