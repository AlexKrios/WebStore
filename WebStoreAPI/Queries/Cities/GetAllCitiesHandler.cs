using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Cities
{
    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<City>>
    {
        private readonly WebStoreContext _context;

        public GetAllCitiesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> Handle(GetAllCitiesQuery command, CancellationToken cancellationToken)
        {
            return await _context.Cities.ToListAsync(cancellationToken);
        }
    }
}