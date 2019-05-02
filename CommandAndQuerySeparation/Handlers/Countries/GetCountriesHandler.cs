using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Countries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Countries
{
    public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IEnumerable<Country>>
    {
        private readonly WebStoreContext _context;

        public GetCountriesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Country>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Countries as IEnumerable<Country>;

                if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                {
                    list = _context.Countries.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                }

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