using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Delete request handler for user
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly WebStoreContext _context;

        public DeleteUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
