using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Types
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<Type>>
    {
        private readonly WebStoreContext _context;

        public GetAllTypesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Type>> Handle(GetAllTypesQuery command, CancellationToken cancellationToken)
        {
            return await _context.Types.ToListAsync(cancellationToken);
        }
    }
}