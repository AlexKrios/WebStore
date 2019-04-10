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
    public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, UpdateCityCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateCityHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateCityCommand> Handle(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Cities.Any(x => x.Id == command.Id)) return null;

                _context.Cities.Update(_mapper.Map<City>(command));
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}