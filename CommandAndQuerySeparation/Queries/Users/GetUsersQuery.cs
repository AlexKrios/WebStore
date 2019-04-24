﻿using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Users;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public GetUsersFilter Filter { get; set; }

        public GetUsersQuery(GetUsersRequest filter)
        {
            Filter = new GetUsersFilter(filter);
        }
    }
}
