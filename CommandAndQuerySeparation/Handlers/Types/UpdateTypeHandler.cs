using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Types;
using DataLibrary;
using MediatR;
using Type = DataLibrary.Entities.Type;

namespace CQS.Handlers.Types
{
    public class UpdateTypeHandler : IRequestHandler<UpdateTypeCommand, Type>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateTypeHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Type> Handle(UpdateTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Types.Any(x => x.Id == command.Id)) return null;

                var type = _mapper.Map<Type>(command);

                _context.Types.Update(type);
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