﻿using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Delete request command for user
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
