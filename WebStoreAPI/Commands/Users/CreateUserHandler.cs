using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request handler for user
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly WebStoreContext _context;
        private readonly IValidator<User> _userValidator;

        public CreateUserHandler(WebStoreContext context, IValidator<User> userValidator)
        {
            _context = context;
            _userValidator = userValidator;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(command.User, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command.User;
        }
    }
}
