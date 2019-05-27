using AutoMapper;
using CQS.Commands.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Roles
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRoleHandler> _logger;

        public CreateRoleHandler(WebStoreContext context, IMapper mapper, ILogger<CreateRoleHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(e, $"CREATE ROLE, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
