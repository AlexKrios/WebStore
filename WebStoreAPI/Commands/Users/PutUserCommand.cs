using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Put request command for user
    public class PutUserCommand : ICommand
    {
        public User Id { get; }

        public PutUserCommand(User id)
        {
            Id = id;
        }
    }
}
