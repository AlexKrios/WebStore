using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Country>
    {
        private readonly WebStoreContext _context;

        public GetCountryByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(GetCountryByIdQuery query, CancellationToken cancellationToken)
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
