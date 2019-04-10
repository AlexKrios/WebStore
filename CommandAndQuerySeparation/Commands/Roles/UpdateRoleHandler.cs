using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Roles
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateRoleCommand> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Roles.Any(x => x.Id == command.Id)) return null;

                _context.Roles.Update(_mapper.Map<Role>(command));
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