using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Type = DataLibrary.Entities.Type;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<Type>>
    {
        private readonly WebStoreContext _context;

        public GetAllTypesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Type>> Handle(GetAllTypesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Types.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}