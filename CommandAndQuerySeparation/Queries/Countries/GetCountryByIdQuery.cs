using MediatR;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetCountryByIdQuery : IRequest<GetCountryByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }

        public GetCountryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
