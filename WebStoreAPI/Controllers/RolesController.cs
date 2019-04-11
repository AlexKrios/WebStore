using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandAndQuerySeparation.Commands.Roles;
using CommandAndQuerySeparation.Queries.Roles;
using CommandAndQuerySeparation.Response.Roles;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public RolesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of roles
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetAllRolesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _mediator.Send(new GetAllRolesQuery());

                if (!roles.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetAllRolesResponse>>(roles));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single role
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetRoleByIdResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _mediator.Send(new GetRoleByIdQuery { Id = id } );

                if (role == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetRoleByIdResponse>(role));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new role
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateRoleCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateRoleCommand role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(role);
                return Ok(role);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change role
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateRoleCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateRoleCommand role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var roleSend = await _mediator.Send(role);
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

        //Delete role
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Role))]
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