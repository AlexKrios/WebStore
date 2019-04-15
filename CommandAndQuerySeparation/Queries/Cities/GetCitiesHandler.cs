using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Cities
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
                return await _context.Cities.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}