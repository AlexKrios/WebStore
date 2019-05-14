using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.UsersRoles;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.UsersRoles
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, DataLibrary.Entities.UserRoles>
    {
        private readonly WebStoreContext _context;

        public DeleteUserRoleHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DataLibrary.Entities.UserRoles> Handle(DeleteUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = await _context.UsersRoles.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (userRole == null) return null;

                _context.UsersRoles.Remove(userRole);
                await _context.SaveChangesAsync(cancellationToken);
                return userRole;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
