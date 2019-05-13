using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.UsersRoles;
using DataLibrary;
using MediatR;

namespace CQS.Handlers.UsersRoles
{
    public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, DataLibrary.Entities.UserRoles>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateUserRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataLibrary.Entities.UserRoles> Handle(CreateUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = _mapper.Map<DataLibrary.Entities.UserRoles>(command);

                await _context.UsersRoles.AddAsync(userRole, cancellationToken);
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
