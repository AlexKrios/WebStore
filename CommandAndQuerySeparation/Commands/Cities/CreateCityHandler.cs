using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Cities
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand, CreateCityCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateCityHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCityCommand> Handle(CreateCityCommand command, CancellationToken cancellationToken)
        {
            await _context.Cities.AddAsync(_mapper.Map<City>(command), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command;
        }
    }
}
