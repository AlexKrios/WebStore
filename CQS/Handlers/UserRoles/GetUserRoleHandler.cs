using CQS.Queries.UserRoles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.UserRoles
{
    public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, UserRole>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetUserRoleHandler> _logger;

        public GetUserRoleHandler(WebStoreContext context, ILogger<GetUserRoleHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UserRole> Handle(GetUserRoleQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USERROLES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
