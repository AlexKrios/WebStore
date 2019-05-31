using CQS.Commands.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Cities
{
    public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, City>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteCityHandler> _logger;

        public DeleteCityHandler(WebStoreContext context, ILogger<DeleteCityHandler> logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.LogError(e, $"DELETE CITY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
