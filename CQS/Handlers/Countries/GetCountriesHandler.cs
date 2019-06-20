using CQS.Queries.Countries;
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

namespace CQS.Handlers.Countries
{
    public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IEnumerable<Country>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetCountriesHandler> _logger;

        public GetCountriesHandler(WebStoreContext context, ILogger<GetCountriesHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Country>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Countries.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip(query.Skip).Take(query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET COUNTRIES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}