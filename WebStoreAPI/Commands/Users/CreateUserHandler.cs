using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request handler for user
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateUserHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateUserCommand> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(_mapper.Map<User>(command), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command;
        }
    }
}
