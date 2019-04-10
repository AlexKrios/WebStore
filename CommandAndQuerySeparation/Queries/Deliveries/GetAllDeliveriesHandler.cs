using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetAllDeliveriesHandler : IRequestHandler<GetAllDeliveriesQuery, IEnumerable<GetAllDeliveriesQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllDeliveriesHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllDeliveriesQuery>> Handle(GetAllDeliveriesQuery query, CancellationToken cancellationToken)
        {
            var deliveries  = await _context.Deliveries.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<Delivery>, IEnumerable<GetAllDeliveriesQuery>>(deliveries);
            return result;
        }
    }
}