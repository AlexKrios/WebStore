using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Put request command for user
    public class UpdateUserCommand : IRequest
    {
        public User User { get; }

        public UpdateUserCommand(User user)
        {
            User = user;
        }
    }
}
