using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Types;
using DataLibrary;
using MediatR;
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

        public Task<IEnumerable<Type>> Handle(GetTypesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Types as IEnumerable<Type>;

                //if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                //{
                //    list = _context.Types.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                //}

                return Task.FromResult(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}