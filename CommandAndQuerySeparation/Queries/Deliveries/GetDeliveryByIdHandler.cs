using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetDeliveryByIdHandler : IRequestHandler<GetDeliveryByIdQuery, GetDeliveryByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetDeliveryByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDeliveryByIdQuery> Handle(GetDeliveryByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
                var result = _mapper.Map<Delivery, GetDeliveryByIdQuery>(delivery);
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
