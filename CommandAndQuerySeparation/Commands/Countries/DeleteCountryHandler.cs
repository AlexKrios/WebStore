using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, Country>
    {
        private readonly WebStoreContext _context;

        public DeleteCountryHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (country == null) return null;

                _context.Countries.Remove(country);
                await _context.SaveChangesAsync(cancellationToken);
                return country;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
