using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Types;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Type = DataLibrary.Entities.Type;

namespace CQS.Handlers.Types
{
    public class GetTypesHandler : IRequestHandler<GetTypesQuery, IEnumerable<Type>>
    {
        private readonly WebStoreContext _context;

        public GetTypesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Type>> Handle(GetTypesQuery query, CancellationToken cancellationToken)
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