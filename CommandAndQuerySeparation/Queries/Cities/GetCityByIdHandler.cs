using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, GetCityByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetCityByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCityByIdQuery> Handle(GetCityByIdQuery query, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var result = _mapper.Map<City, GetCityByIdQuery>(city);
            return result;
        }
    }
}
