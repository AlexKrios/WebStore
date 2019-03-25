using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Change command for user model
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
