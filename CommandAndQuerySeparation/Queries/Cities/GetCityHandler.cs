using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetCityHandler : IRequestHandler<GetCityQuery, City>
    {
        private readonly WebStoreContext _context;

        public GetCityHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(GetCityQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Cities.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
