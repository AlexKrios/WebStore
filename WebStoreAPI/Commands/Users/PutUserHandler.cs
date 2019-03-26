using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Change command for user model
    public class PutUserHandler : PutUser<User>
    {
        private readonly WebStoreContext _context;
        public PutUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override void Execute(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
