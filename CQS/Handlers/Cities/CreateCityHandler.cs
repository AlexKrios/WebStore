using AutoMapper;
using CQS.Commands.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Cities
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand, City>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCityHandler> _logger;

        public CreateCityHandler(WebStoreContext context, IMapper mapper, ILogger<CreateCityHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(e, $"CREATE CITY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
