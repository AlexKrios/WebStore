using System;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
