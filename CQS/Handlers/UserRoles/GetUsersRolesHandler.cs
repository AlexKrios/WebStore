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

namespace CQS.Handlers.UserRoles
{
    public class GetUsersRolesHandler : IRequestHandler<GetUsersRolesQuery, IEnumerable<UserRole>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetUsersRolesHandler> _logger;

        public GetUsersRolesHandler(WebStoreContext context, ILogger<GetUsersRolesHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<UserRole>> Handle(GetUsersRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.UserRoles.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip(query.Skip).Take(query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USERSROLES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}