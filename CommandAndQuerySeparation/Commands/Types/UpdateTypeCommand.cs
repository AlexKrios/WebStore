using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class UpdateTypeCommand : IRequest<Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
