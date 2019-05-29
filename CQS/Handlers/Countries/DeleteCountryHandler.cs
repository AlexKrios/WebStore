using CQS.Commands.Countries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Countries
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, Country>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteCountryHandler> _logger;

        public DeleteCountryHandler(WebStoreContext context, ILogger<DeleteCountryHandler> logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.LogError(e, $"DELETE COUNTRY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
