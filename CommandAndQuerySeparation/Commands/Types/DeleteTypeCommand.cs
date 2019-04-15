using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Types
{
    public class DeleteTypeCommand : IRequest<Type>
    {
        public int Id { get; set; }
    }
}
