using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    public class DeleteUserHandler : Command<User>
    {
        private readonly WebStoreContext _context;
        public DeleteUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override void Execute(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
