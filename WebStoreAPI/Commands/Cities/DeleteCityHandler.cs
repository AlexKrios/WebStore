using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Commands.Cities
{
    public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, DeleteCityCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteCityHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteCityCommand> Handle(DeleteCityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (city == null) return null;

                _context.Cities.Remove(city);
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
