using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIModels.Filters;
using APIModels.Requests.Roles;
using APIModels.Response.Roles;
using AutoMapper;
using CQS.Commands.Roles;
using CQS.Queries.Roles;

namespace WebStoreAPI.Controllers
{
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
        /// Get all Roles.
        /// </summary>
        /// <returns>List with all Roles.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetRolesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetRolesRequest request)
        {
            try
            {
                var roles = await _mediator.Send(new GetRolesQuery
                {
                    Filter = new GetRolesFilter { Request = request }
                });

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
        /// Get Role by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Role.</param>
        /// <returns>Info about Role with selected Id.</returns>
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
        /// Create a new Role.
        /// </summary>
        /// <param name="role">The body of new Role.</param>
        /// <returns>Info about created Role.</returns>
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
        /// Update existing Role.
        /// </summary>
        /// <param name="role">The body of new Role.</param>
        /// <returns>Nothing</returns>
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
        /// Delete existing Role.
        /// </summary>
        /// <param name="id">The ID of the desired Role.</param>
        /// <returns>Nothing</returns>
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