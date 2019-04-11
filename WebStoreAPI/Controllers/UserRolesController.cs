﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandAndQuerySeparation.Commands.UserRoles;
using CommandAndQuerySeparation.Queries.UserRoles;
using CommandAndQuerySeparation.Response.UserRoles;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public UserRolesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of userRoles
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetAllUsersRolesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usersRoles = await _mediator.Send(new GetAllUserRolesQuery());

                if (!usersRoles.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetAllUsersRolesResponse>>(usersRoles));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Get single userRole
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetUserRolesByIdResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var userRoles = await _mediator.Send(new GetUserRoleByIdQuery { Id = id } );

                if (userRoles == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetUserRolesByIdResponse>(userRoles));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Add new userRole
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserRoleCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserRoleCommand userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(userRole);
                return Ok(userRole);
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Change userRole
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserRoleCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserRoleCommand userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(userRole);
                if (userRoleSend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Delete userRole
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(UserRole))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(new DeleteUserRoleCommand { Id = id });
                if (userRoleSend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}