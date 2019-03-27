﻿using System.Threading.Tasks;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request handler for user
    public class PostUserHandler : ICommandHandler<PostUserCommand>
    {
        private readonly WebStoreContext _context;

        public PostUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task Execute(PostUserCommand command)
        {
            await _context.Users.AddAsync(command.Id);
            await _context.SaveChangesAsync();
        }
    }
}
