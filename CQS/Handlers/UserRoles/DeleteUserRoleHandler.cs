using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.UserRoles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.UserRoles
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, UserRole>
    {
        private readonly WebStoreContext _context;

        public DeleteUserRoleHandler(WebStoreContext context)
        {
            _context = context;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
