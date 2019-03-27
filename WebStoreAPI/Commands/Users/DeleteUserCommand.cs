﻿using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Delete request command for user
    public class DeleteUserCommand : ICommand
    {
        public User Id { get; }

        public DeleteUserCommand(User id)
        {
            Id = id;
        }
    }
}
