using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetAllManufacturersHandler : IRequestHandler<GetAllManufacturersQuery, IEnumerable<GetAllManufacturersQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllManufacturersHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllManufacturersQuery>> Handle(GetAllManufacturersQuery query, CancellationToken cancellationToken)
        {
            var manufacturers = await _context.Manufacturers.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<Manufacturer>, IEnumerable<GetAllManufacturersQuery>>(manufacturers);
            return result;
        }
    }
}