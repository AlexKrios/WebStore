using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.UsersFolder.Handlers
{
    public class PostUserHandler : Command<User>
    {
        public PostUserHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
