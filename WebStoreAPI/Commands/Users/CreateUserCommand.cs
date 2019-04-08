﻿using MediatR;

namespace WebStoreAPI.Commands.Users
{
    public class CreateUserCommand : IRequest<CreateUserCommand>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}
