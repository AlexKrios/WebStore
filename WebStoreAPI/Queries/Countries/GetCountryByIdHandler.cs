using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Countries
{
    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Country>
    {
        private readonly WebStoreContext _context;

        public GetCountryByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(GetCountryByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
