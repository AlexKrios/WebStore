using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Cities
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand, City>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateCityHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<City> Handle(CreateCityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var city = _mapper.Map<City>(command);

                await _context.Cities.AddAsync(city, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return city;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
