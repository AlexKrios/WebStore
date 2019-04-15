using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Cities
{
    public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, City>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateCityHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<City> Handle(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Cities.Any(x => x.Id == command.Id)) return null;

                var city = _mapper.Map<City>(command);

                _context.Cities.Update(city);
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