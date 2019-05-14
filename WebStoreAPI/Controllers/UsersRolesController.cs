using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.UsersRoles;
using CQS.Queries.UsersRoles;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.UsersRoles;
using WebStoreAPI.Response.UsersRoles;
using WebStoreAPI.Specifications.UserRoles;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersRolesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersRolesController> _logger;

        public UsersRolesController(IMediator mediator, IMapper mapper, ILogger<UsersRolesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all UsersRoles.
        /// </summary>
        /// <returns>List with all UsersRoles.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetUsersRolesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetUsersRolesRequest request)
        {
            try
            {
                var userIdSpec = new UserRolesUserIdSpecification(request.UserId);
                var roleIdSpec = new UserRolesRoleIdSpecification(request.RoleId);

                var specification = userIdSpec && roleIdSpec;

                var usersRoles = await _mediator.Send(new GetUsersRolesQuery { Specification = specification });

                if (!usersRoles.Any())
                {
                    _logger.LogError("GET USERSROLES - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USERSROLES - Complete");
                return Ok(_mapper.Map<IEnumerable<GetUsersRolesResponse>>(usersRoles));
            }
            catch (Exception e)
            {
                _logger.LogError(@"GET USERSROLES - {0}", e);
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Get UsersRoles by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired UsersRoles.</param>
        /// <returns>Info about UsersRoles with selected Id.</returns>
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
                    _logger.LogError("GET USERROLES - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USERROLES - Complete");
                return Ok(_mapper.Map<GetUserRolesResponse>(userRoles));
            }
            catch (Exception e)
            {
                _logger.LogError(@"GET USERROLES - {0}", e);
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Create a new UsersRoles.
        /// </summary>
        /// <param name="userRole">The body of new UsersRoles.</param>
        /// <returns>Info about created UsersRoles.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserRolesRequest userRole)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("POST USERROLES - Not valid model");
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(_mapper.Map<CreateUserRoleCommand>(userRole));
                _logger.LogInformation("POST USERROLES - Complete, with id: " + userRoleSend.Id);
                return Created($"api/userroles/{userRoleSend.Id}", _mapper.Map<CreateUserRolesResponse>(userRoleSend));
            }
            catch (Exception e)
            {
                _logger.LogError(@"POST USERROLES - {0}", e);
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Update existing UsersRoles.
        /// </summary>
        /// <param name="userRole">The body of new UsersRoles.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserRolesRequest userRole)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("UPDATE USERROLES - Not valid model");
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(_mapper.Map<UpdateUserRoleCommand>(userRole));
                if (userRoleSend == null)
                {
                    _logger.LogError("UPDATE USERROLES - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE USERROLES - Complete, with id: " + userRoleSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(@"UPDATE USERROLES - {0}", e);
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Delete existing UsersRoles.
        /// </summary>
        /// <param name="id">The ID of the desired UsersRoles.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userRoleSend = await _mediator.Send(new DeleteUserRoleCommand { Id = id });
                if (userRoleSend == null)
                {
                    _logger.LogError("DELETE USERROLES - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE USERROLES - Complete, with id: " + userRoleSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(@"DELETE USERROLES - {0}", e);
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}