using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.UserRoles;
using CQS.Queries.UserRoles;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.UserRoles;
using WebStoreAPI.Response.UserRoles;
using WebStoreAPI.Specifications.UserRoles;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRolesController> _logger;

        public UserRolesController(IMediator mediator, IMapper mapper, ILogger<UserRolesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all UserRole.
        /// </summary>
        /// <returns>List with all UserRole.</returns>
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
                    _logger.LogInformation("GET USERSROLES, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USERSROLES, CONTROLLER - Complete");
                return Ok(_mapper.Map<IEnumerable<GetUsersRolesResponse>>(usersRoles));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USERSROLES, CONTROLLER - {e.Message}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Get UserRole by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired UserRole.</param>
        /// <returns>Info about UserRole with selected Id.</returns>
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
                    _logger.LogInformation("GET USERROLES, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USERROLES, CONTROLLER - Complete");
                return Ok(_mapper.Map<GetUserRolesResponse>(userRoles));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USERROLES, CONTROLLER - {e.Message}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Create a new UserRole.
        /// </summary>
        /// <param name="userRole">The body of new UserRole.</param>
        /// <returns>Info about created UserRole.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserRolesRequest userRole)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("CREATE USERROLES, CONTROLLER - Not valid model");
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(_mapper.Map<CreateUserRoleCommand>(userRole));
                _logger.LogInformation("CREATE USERROLES, CONTROLLER - Complete, with id: " + userRoleSend.Id);
                return Created($"api/userroles/{userRoleSend.Id}", _mapper.Map<CreateUserRolesResponse>(userRoleSend));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE USERROLES, CONTROLLER - {e.Message}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Update existing UserRole.
        /// </summary>
        /// <param name="userRole">The body of new UserRole.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserRolesResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserRolesRequest userRole)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("UPDATE USERROLES, CONTROLLER - Not valid model");
                return BadRequest(ModelState);
            }

            try
            {
                var userRoleSend = await _mediator.Send(_mapper.Map<UpdateUserRoleCommand>(userRole));
                if (userRoleSend == null)
                {
                    _logger.LogInformation("UPDATE USERROLES, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE USERROLES, CONTROLLER - Complete, with id: " + userRoleSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE USERROLES, CONTROLLER - {e.Message}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Delete existing UserRole.
        /// </summary>
        /// <param name="id">The ID of the desired UserRole.</param>
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
                    _logger.LogInformation("DELETE USERROLES, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE USERROLES, CONTROLLER - Complete, with id: " + userRoleSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE USERROLES, CONTROLLER - {e.Message}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}