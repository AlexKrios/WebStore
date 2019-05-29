using AutoMapper;
using CQS.Commands.Cities;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Cities
{
    public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, City>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCityHandler> _logger;

        public UpdateCityHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateCityHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(e, $"UPDATE CITY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}