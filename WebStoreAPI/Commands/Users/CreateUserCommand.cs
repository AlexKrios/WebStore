using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request command for user
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; }

        public CreateUserCommand(User user)
        {
            User = user;
        }
    }
}
