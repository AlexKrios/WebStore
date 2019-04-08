using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;

namespace WebStoreAPI.Commands.Users
{
    //Delete request handler for user
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteUserCommand> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (user == null) return null;

                _context.Users.Remove(user);
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
