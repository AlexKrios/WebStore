using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using MediatR;
using Type = DataLibrary.Entities.Type;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class CreateTypeHandler : IRequestHandler<CreateTypeCommand, CreateTypeCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateTypeHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateTypeCommand> Handle(CreateTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Types.AddAsync(_mapper.Map<Type>(command), cancellationToken);
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
