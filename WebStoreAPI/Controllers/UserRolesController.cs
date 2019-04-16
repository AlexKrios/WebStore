using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.UserRoles;
using CQS.Queries.UserRoles;
using WebStoreAPI.Requests.UserRoles;
using WebStoreAPI.Response.UserRoles;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserRolesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all UsersRoles.
        /// </summary>
        /// <returns>List with all UsersRoles.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetUsersRolesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usersRoles = await _mediator.Send(new GetUsersRolesQuery());

                if (!usersRoles.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetUsersRolesResponse>>(usersRoles));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Get UserRoles by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired UserRoles.</param>
        /// <returns>Info about UserRoles with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var userRoles = await _mediator.Send(new GetUserRoleQuery { Id = id } );

                if (userRoles == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetUserRolesResponse>(userRoles));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Create a new UserRoles.
        /// </summary>
        /// <param name="userRole">The body of new UserRoles.</param>
        /// <returns>Info about created UserRoles.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserRolesRequest userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(_mapper.Map<CreateUserRoleCommand>(userRole));
                return Created($"api/userroles/{userRoleSend.Id}", _mapper.Map<CreateUserRolesResponse>(userRoleSend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Update existing UserRoles.
        /// </summary>
        /// <param name="userRole">The body of new UserRoles.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserRolesRequest userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(_mapper.Map<UpdateUserRoleCommand>(userRole));
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

        /// <summary>
        /// Delete existing UserRoles.
        /// </summary>
        /// <param name="id">The ID of the desired UserRoles.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteUserRolesResponse))]
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