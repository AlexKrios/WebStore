using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetManufacturerByIdHandler : IRequestHandler<GetManufacturerByIdQuery, GetManufacturerByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetManufacturerByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetManufacturerByIdQuery> Handle(GetManufacturerByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
                var result = _mapper.Map<Manufacturer, GetManufacturerByIdQuery>(manufacturer);
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
