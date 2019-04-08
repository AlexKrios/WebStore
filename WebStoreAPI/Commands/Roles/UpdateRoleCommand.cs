﻿using MediatR;

namespace WebStoreAPI.Commands.Roles
{
    public class UpdateRoleCommand : IRequest<UpdateRoleCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
