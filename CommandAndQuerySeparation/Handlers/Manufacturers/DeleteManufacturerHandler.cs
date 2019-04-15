using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Manufacturers
{
    public class DeleteCityHandler : IRequestHandler<DeleteManufacturerCommand, Manufacturer>
    {
        private readonly WebStoreContext _context;

        public DeleteCityHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Manufacturer> Handle(DeleteManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (manufacturer == null) return null;

                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync(cancellationToken);
                return manufacturer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
