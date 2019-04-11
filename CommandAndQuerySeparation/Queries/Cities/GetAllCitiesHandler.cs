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
    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<City>>
    {
        private readonly WebStoreContext _context;

        public GetAllCitiesHandler(WebStoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> Handle(GetAllCitiesQuery query, CancellationToken cancellationToken)
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