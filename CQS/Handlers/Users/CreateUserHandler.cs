using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateUserHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(command);

                await _context.Users.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
