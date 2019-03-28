using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Put request handler for user
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly WebStoreContext _context;

        public UpdateUserHandler(WebStoreContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            _context.Users.Update(command.User);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
