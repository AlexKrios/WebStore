using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Commands.Roles
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteRoleHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteRoleCommand> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (role == null) return null;

                _context.Roles.Remove(role);
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
