using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.UserRoles
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, UpdateUserRoleCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateUserRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateUserRoleCommand> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.UserRoles.Any(x => x.Id == command.Id)) return null;

                _context.UserRoles.Update(_mapper.Map<UserRole>(command));
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