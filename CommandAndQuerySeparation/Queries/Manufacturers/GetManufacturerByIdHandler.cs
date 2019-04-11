using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetManufacturerByIdHandler : IRequestHandler<GetManufacturerByIdQuery, Manufacturer>
    {
        private readonly WebStoreContext _context;

        public GetManufacturerByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Manufacturer> Handle(GetManufacturerByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
