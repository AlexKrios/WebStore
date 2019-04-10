using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetAllUserRolesHandler : IRequestHandler<GetAllUserRolesQuery, IEnumerable<GetAllUserRolesQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllUserRolesHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllUserRolesQuery>> Handle(GetAllUserRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var userRoles = await _context.UserRoles.ToListAsync(cancellationToken);
                var result = _mapper.Map<IEnumerable<UserRole>, IEnumerable<GetAllUserRolesQuery>>(userRoles);
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