using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request handler for user
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly WebStoreContext _context;

        public CreateUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(command.User, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command.User;
        }
    }
}
