using MediatR;
using WebStoreAPI.Mapper;

namespace WebStoreAPI.Commands.Users
{
    //Post request command for user
    public class CreateUserCommand : IRequest<UserDto>
    {
        public UserDto UserDto { get; }

        public CreateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
