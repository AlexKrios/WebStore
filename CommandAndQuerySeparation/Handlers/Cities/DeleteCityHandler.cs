using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Cities
{
    public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, City>
    {
        private readonly WebStoreContext _context;

        public DeleteCityHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<City> Handle(DeleteCityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (city == null) return null;

                _context.Cities.Remove(city);
                await _context.SaveChangesAsync(cancellationToken);
                return city;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
