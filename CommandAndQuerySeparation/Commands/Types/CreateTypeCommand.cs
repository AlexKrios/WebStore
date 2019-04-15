using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class CreateTypeCommand : IRequest<Type>
    {
        public string Name { get; set; }
    }
}
