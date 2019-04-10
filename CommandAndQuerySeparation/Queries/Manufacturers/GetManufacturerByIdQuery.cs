using MediatR;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetManufacturerByIdQuery : IRequest<GetManufacturerByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Rating { get; set; }

        public GetManufacturerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
