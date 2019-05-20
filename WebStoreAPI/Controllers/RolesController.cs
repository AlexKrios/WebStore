using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Roles;
using CQS.Queries.Roles;
using WebStoreAPI.Requests.Roles;
using WebStoreAPI.Response.Roles;
using WebStoreAPI.Specifications.Roles;

namespace WebStoreAPI.Controllers
{
    /// <summary>
    /// Roles controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RolesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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

                var roles = await _mediator.Send(new GetRolesQuery { Specification = nameSpec });

                if (!roles.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetRolesResponse>>(roles));
            }
            catch (Exception e)
            {
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
                var role = await _mediator.Send(new GetRoleQuery { Id = id } );

                if (role == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetRoleResponse>(role));
            }
            catch (Exception e)
            {
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
                return BadRequest(ModelState);
            }

            try
            {
                var roleSend = await _mediator.Send(_mapper.Map<CreateRoleCommand>(role));
                return Created($"api/roles/{roleSend.Id}", _mapper.Map<CreateRoleResponse>(roleSend));
            }
            catch (Exception e)
            {
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
                return BadRequest(ModelState);
            }

            try
            {
                var roleSend = await _mediator.Send(_mapper.Map<UpdateRoleCommand>(role));
                if (roleSend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var roleSend = await _mediator.Send(new DeleteRoleCommand { Id = id });
                if (roleSend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}