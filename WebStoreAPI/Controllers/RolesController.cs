using AutoMapper;
using CQS.Commands.Roles;
using CQS.Queries.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStoreAPI.Requests.Roles;
using WebStoreAPI.Response.Roles;
using WebStoreAPI.Specifications.Roles;

namespace WebStoreAPI.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Roles controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<RolesController> _logger;

        public RolesController(IMediator mediator, IMapper mapper, ILogger<RolesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Roles
        /// </summary>
        /// <returns>List with all Roles</returns>
        /// <responce code="200">Get Roles by filter</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Roles not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetRolesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetRolesRequest request)
        {
            try
            {
                var nameSpec = new RoleNameSpecification(request.Name);

                var roles = await _mediator.Send(new GetRolesQuery
                {
                    Skip = 0,
                    Take = 10,
                    Specification = nameSpec
                });

                if (!roles.Any())
                {
                    _logger.LogInformation("GET ROLES, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ROLES, CONTROLLER - Complete");
                return Ok(_mapper.Map<IEnumerable<GetRolesResponse>>(roles));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ROLES, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Role by their ID
        /// </summary>
        /// <param name="id">The ID of the desired Role</param>
        /// <returns>Info about Role with selected Id</returns>
        /// <responce code="200">Get Role by Id</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Role not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetRoleResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _mediator.Send(new GetRoleQuery { Id = id });

                if (role == null)
                {
                    _logger.LogInformation("GET ROLE, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ROLE, CONTROLLER - Complete");
                return Ok(_mapper.Map<GetRoleResponse>(role));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ROLE, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Role
        /// </summary>
        /// <param name="role">The body of new Role</param>
        /// <returns>Info about created Role</returns>
        /// <responce code="200">Create Role</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateRoleResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateRoleRequest role)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("CREATE ROLE, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var roleSend = await _mediator.Send(_mapper.Map<CreateRoleCommand>(role));
                _logger.LogInformation("CREATE ROLE, CONTROLLER - Complete, with id: " + roleSend.Id);
                return Created($"api/roles/{roleSend.Id}", _mapper.Map<CreateRoleResponse>(roleSend));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE ROLE, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Role
        /// </summary>
        /// <param name="role">The body of new Role</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Update Role</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Role not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateRoleResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateRoleRequest role)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("UPDATE ROLE, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var roleSend = await _mediator.Send(_mapper.Map<UpdateRoleCommand>(role));
                if (roleSend == null)
                {
                    _logger.LogInformation("UPDATE ROLE, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE ROLE, CONTROLLER - Complete, with id: " + roleSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE ROLE, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing Role
        /// </summary>
        /// <param name="id">The ID of the desired Role</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Delete Role</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Role not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteRoleResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var roleSend = await _mediator.Send(new DeleteRoleCommand { Id = id });
                if (roleSend == null)
                {
                    _logger.LogInformation("DELETE ROLE, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE ROLE, CONTROLLER - Complete, with id: " + roleSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE ROLE, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}