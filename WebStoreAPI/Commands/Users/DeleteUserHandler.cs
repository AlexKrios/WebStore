using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
            _context.Users.Remove(command.User);
            await _context.SaveChangesAsync();
            return command.User;
        }
    }
}
