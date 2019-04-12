using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.UserRoles
{
    public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, UserRole>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateUserRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserRole> Handle(CreateUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = _mapper.Map<UserRole>(command);

                await _context.UserRoles.AddAsync(userRole, cancellationToken);
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
