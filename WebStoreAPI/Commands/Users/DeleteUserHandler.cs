using System.Threading.Tasks;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Delete request handler for user
    public class DeleteUserHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task Execute(DeleteUserCommand command)
        {
            _context.Users.Remove(command.Id);
            await _context.SaveChangesAsync();
        }
    }
}
