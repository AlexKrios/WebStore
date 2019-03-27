using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request command for user
    public class PostUserCommand : ICommand
    {
        public User Id { get; }

        public PostUserCommand(User id)
        {
            Id = id;
        }
    }
}
