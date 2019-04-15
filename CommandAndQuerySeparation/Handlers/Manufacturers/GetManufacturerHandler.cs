using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Manufacturers
{
    public class GetManufacturerHandler : IRequestHandler<GetManufacturerQuery, Manufacturer>
    {
        private readonly WebStoreContext _context;

        public GetManufacturerHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Manufacturer> Handle(GetManufacturerQuery query, CancellationToken cancellationToken)
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
