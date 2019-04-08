using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Commands.Manufacturers
{
    public class DeleteCityHandler : IRequestHandler<DeleteManufacturerCommand, DeleteManufacturerCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteCityHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteManufacturerCommand> Handle(DeleteManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (manufacturer == null) return null;

                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
