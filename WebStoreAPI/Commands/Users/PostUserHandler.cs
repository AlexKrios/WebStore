using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    public class PostUserHandler : Command<User>
    {
        private readonly WebStoreContext _context;
        public PostUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override void Execute(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
