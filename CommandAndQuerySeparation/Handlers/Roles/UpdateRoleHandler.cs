using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Roles
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Role>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Role> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Roles.Any(x => x.Id == command.Id)) return null;

                var role = _mapper.Map<Role>(command);

                _context.Roles.Update(role);
                await _context.SaveChangesAsync(cancellationToken);
                return role;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}