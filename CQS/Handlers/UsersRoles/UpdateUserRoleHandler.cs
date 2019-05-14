using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.UsersRoles;
using DataLibrary;
using MediatR;

namespace CQS.Handlers.UsersRoles
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, DataLibrary.Entities.UserRoles>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateUserRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataLibrary.Entities.UserRoles> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.UsersRoles.Any(x => x.Id == command.Id)) return null;

                var userRole = _mapper.Map<DataLibrary.Entities.UserRoles>(command);

                _context.UsersRoles.Update(userRole);
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