using MediatR;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class UpdateTypeCommand : IRequest<UpdateTypeCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
