using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Cities
{
    public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IEnumerable<City>>
    {
        private readonly WebStoreContext _context;

        public GetCitiesHandler(WebStoreContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<City>> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Cities as IEnumerable<City>;

                if (query.Filter.Request.CountryId.HasValue)
                {
                    list = _context.Cities.Where(o => query.Filter.CountryId.IsSatisfiedBy(o));
                }

                if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                {
                    list = _context.Cities.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
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