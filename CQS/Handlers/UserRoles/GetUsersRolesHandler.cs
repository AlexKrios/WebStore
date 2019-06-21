using CQS.Queries.UserRoles;
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
using Microsoft.Extensions.Configuration;

namespace CQS.Handlers.UserRoles
{
    public class GetUsersRolesHandler : IRequestHandler<GetUsersRolesQuery, IEnumerable<UserRole>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetUsersRolesHandler> _logger;
        private readonly IConfiguration _config;

        public GetUsersRolesHandler(WebStoreContext context, ILogger<GetUsersRolesHandler> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<UserRole>> Handle(GetUsersRolesQuery query, CancellationToken cancellationToken)
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

                return await _context.UserRoles.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip((int)query.Skip).Take((int)query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USERSROLES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}