using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Roles
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Role>
    {
        private readonly WebStoreContext _context;

        public DeleteRoleHandler(WebStoreContext context)
        {
            _context = context;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
