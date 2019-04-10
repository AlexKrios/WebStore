using MediatR;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetCityByIdQuery : IRequest<GetCityByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public GetCityByIdQuery(int id)
        {
            Id = id;
        }
    }
}
