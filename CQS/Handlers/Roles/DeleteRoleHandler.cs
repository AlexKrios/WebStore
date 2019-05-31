using CQS.Commands.Roles;
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
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Role>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteRoleHandler> _logger;

        public DeleteRoleHandler(WebStoreContext context, ILogger<DeleteRoleHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Role> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (role == null) return null;

                _context.Roles.Remove(role);
                await _context.SaveChangesAsync(cancellationToken);
                return role;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE ROLE, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
