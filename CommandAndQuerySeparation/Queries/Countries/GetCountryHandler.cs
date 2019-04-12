using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetCountryHandler : IRequestHandler<GetCountryQuery, Country>
    {
        private readonly WebStoreContext _context;

        public GetCountryHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(GetCountryQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Countries.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
