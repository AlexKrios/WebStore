using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllUsersQuery>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users.ToListAsync(cancellationToken);
                var result = _mapper.Map<IEnumerable<User>, IEnumerable<GetAllUsersQuery>>(users);
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
