using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Put request handler for user
    public class PutUserHandler : IRequestHandler<PutUserCommand, User>
    {
        private readonly WebStoreContext _context;

        public PutUserHandler(WebStoreContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(PutUserCommand command, CancellationToken cancellationToken)
        {
            _context.Users.Update(command.User);
            await _context.SaveChangesAsync(cancellationToken);
            return command.User;
        }
    }
}
