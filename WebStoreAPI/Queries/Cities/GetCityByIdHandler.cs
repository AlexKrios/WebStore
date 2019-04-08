using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Cities
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, City>
    {
        private readonly WebStoreContext _context;

        public GetCityByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(GetCityByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Cities.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
