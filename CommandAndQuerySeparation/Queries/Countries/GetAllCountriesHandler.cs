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
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<Country>>
    {
        private readonly WebStoreContext _context;

        public GetAllCountriesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
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