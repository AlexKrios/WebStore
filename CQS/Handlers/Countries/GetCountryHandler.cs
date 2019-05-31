using CQS.Queries.Countries;
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
    public class GetCountryHandler : IRequestHandler<GetCountryQuery, Country>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetCountryHandler> _logger;

        public GetCountryHandler(WebStoreContext context, ILogger<GetCountryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Country> Handle(GetCountryQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Countries.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET COUNTRY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
