using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebStoreAPI.Mapper;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request handler for user
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateUserHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(_mapper.Map<User>(command.UserDto), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command.UserDto;
        }
    }
}
