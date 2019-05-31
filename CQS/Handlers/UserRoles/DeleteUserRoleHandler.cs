using CQS.Commands.UserRoles;
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
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, UserRole>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteUserRoleHandler> _logger;

        public DeleteUserRoleHandler(WebStoreContext context, ILogger<DeleteUserRoleHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UserRole> Handle(DeleteUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (userRole == null) return null;

                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync(cancellationToken);
                return userRole;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE USERROLES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
