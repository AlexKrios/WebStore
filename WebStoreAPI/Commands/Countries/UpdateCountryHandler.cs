using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.Countries
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, UpdateCountryCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateCountryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateCountryCommand> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Countries.Any(x => x.Id == command.Id)) return null;

                _context.Countries.Update(_mapper.Map<Country>(command));
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