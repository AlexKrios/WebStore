using CQS.Queries.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Roles
{
    public class GetRoleHandler : IRequestHandler<GetRoleQuery, Role>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetRoleHandler> _logger;

        public GetRoleHandler(WebStoreContext context, ILogger<GetRoleHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Role> Handle(GetRoleQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Roles.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ROLE, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
