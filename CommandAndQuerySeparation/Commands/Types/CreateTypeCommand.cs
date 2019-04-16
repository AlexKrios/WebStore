using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Types
{
    public class CreateTypeCommand : IRequest<Type>
    {
        public string Name { get; set; }
    }
}
