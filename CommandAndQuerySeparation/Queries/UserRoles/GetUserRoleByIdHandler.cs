using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, GetUserRoleByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetUserRoleByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserRoleByIdQuery> Handle(GetUserRoleByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
                var result = _mapper.Map<UserRole, GetUserRoleByIdQuery>(userRole);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
