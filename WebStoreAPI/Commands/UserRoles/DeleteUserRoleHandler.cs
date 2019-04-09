using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Commands.UserRoles
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, DeleteUserRoleCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteUserRoleHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteUserRoleCommand> Handle(DeleteUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (userRole == null) return null;

                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
