using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.UserRoles
{
    public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, CreateUserRoleCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateUserRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateUserRoleCommand> Handle(CreateUserRoleCommand command, CancellationToken cancellationToken)
        {
            await _context.UserRoles.AddAsync(_mapper.Map<UserRole>(command), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command;
        }
    }
}
