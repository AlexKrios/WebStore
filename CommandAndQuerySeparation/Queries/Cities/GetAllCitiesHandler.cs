using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<GetAllCitiesQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllCitiesHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllCitiesQuery>> Handle(GetAllCitiesQuery query, CancellationToken cancellationToken)
        {
            var cities = await _context.Cities.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<City>, IEnumerable<GetAllCitiesQuery>>(cities);
            return result;
        }
    }
}