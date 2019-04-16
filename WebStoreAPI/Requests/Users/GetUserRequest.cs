﻿using System;

namespace WebStoreAPI.Requests.Users
{
    public class GetUserRequest
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