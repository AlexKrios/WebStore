using CQS.Queries.Roles;
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

namespace CQS.Handlers.Roles
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetRolesHandler> _logger;

        public GetRolesHandler(WebStoreContext context, ILogger<GetRolesHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Role>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Roles.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ROLES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}