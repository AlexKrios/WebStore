﻿using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Users
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}