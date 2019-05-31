using CQS.Queries.Cities;
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
    public class GetCityHandler : IRequestHandler<GetCityQuery, City>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetCityHandler> _logger;

        public GetCityHandler(WebStoreContext context, ILogger<GetCityHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<City> Handle(GetCityQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Cities.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET CITY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
