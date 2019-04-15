using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Types;
using DataLibrary;
using MediatR;
using Type = DataLibrary.Entities.Type;

namespace CQS.Handlers.Types
{
    public class CreateTypeHandler : IRequestHandler<CreateTypeCommand, Type>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateTypeHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Type> Handle(CreateTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var type = _mapper.Map<Type>(command);

                await _context.Types.AddAsync(type, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return type;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
