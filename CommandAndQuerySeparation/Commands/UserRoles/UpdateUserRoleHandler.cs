using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.UserRoles
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, UserRole>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateUserRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserRole> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.UserRoles.Any(x => x.Id == command.Id)) return null;

                var userRole = _mapper.Map<UserRole>(command);

                _context.UserRoles.Update(userRole);
                await _context.SaveChangesAsync(cancellationToken);
                return userRole;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}