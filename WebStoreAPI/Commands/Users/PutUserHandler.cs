using System.Threading.Tasks;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Put request handler for user
    public class PutUserHandler : ICommandHandler<PutUserCommand>
    {
        private readonly WebStoreContext _context;

        public PutUserHandler(WebStoreContext context)
        {
            _context = context;
        }
        public async Task Execute(PutUserCommand command)
        {
            _context.Update(command.Id);
            await _context.SaveChangesAsync();
        }
    }
}
