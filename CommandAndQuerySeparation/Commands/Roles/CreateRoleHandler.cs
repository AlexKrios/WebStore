using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Roles
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, CreateRoleCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateRoleCommand> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Roles.AddAsync(_mapper.Map<Role>(command), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
