using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.UsersFolder.Handlers
{
    public class PutUserHandler : Command<User>
    {
        public PutUserHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(User user)
        {
            Context.Update(user);
            Context.SaveChanges();
        }
    }
}
