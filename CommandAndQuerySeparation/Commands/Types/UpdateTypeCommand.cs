using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Types
{
    public class UpdateTypeCommand : IRequest<Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
