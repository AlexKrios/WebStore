using CQS.Queries.Countries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;

        public GetCountriesHandler(WebStoreContext context, ILogger<GetCountriesHandler> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<Country>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (query.Skip == null)
                {
                    query.Skip = Convert.ToInt32(_config["Pagination:Skip"]);
                }

                if (query.Take == null)
                {
                    query.Take = Convert.ToInt32(_config["Pagination:Take"]);
                }

                return await _context.Countries.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip((int)query.Skip).Take((int)query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET COUNTRIES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}