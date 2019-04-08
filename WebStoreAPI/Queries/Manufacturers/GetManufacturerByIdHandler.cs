using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Manufacturers
{
    public class GetManufacturerByIdHandler : IRequestHandler<GetManufacturerByIdQuery, Manufacturer>
    {
        private readonly WebStoreContext _context;

        public GetManufacturerByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Manufacturer> Handle(GetManufacturerByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
