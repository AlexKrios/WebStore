using CQS.Queries.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Cities
{
    public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IEnumerable<City>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetCitiesHandler> _logger;

        public GetCitiesHandler(WebStoreContext context, ILogger<GetCitiesHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<City>> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Cities.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip(query.Skip).Take(query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET CITIES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}