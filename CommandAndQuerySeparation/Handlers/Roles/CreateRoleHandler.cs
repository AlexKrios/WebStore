using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Roles
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateRoleHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Role> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var role = _mapper.Map<Role>(command);

                await _context.Roles.AddAsync(role, cancellationToken);
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
