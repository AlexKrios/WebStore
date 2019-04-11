using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, City>
    {
        private readonly WebStoreContext _context;

        public GetCityByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(GetCityByIdQuery query, CancellationToken cancellationToken)
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
