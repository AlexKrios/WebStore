using System;
using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}
