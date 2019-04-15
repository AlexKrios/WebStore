using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class DeleteTypeCommand : IRequest<Type>
    {
        public int Id { get; set; }
    }
}
