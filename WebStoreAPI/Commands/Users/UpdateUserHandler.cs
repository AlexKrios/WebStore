using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Put request handler for user
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateUserHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            _context.Users.Update(_mapper.Map<User>(command));
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
