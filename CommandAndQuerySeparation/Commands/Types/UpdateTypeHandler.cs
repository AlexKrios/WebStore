using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using MediatR;
using Type = DataLibrary.Entities.Type;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class UpdateTypeHandler : IRequestHandler<UpdateTypeCommand, UpdateTypeCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateTypeHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateTypeCommand> Handle(UpdateTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Types.Any(x => x.Id == command.Id)) return null;

                _context.Types.Update(_mapper.Map<Type>(command));
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