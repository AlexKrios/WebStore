using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Users;
using CQS.Queries.Users;
using WebStoreAPI.Requests.Users;
using WebStoreAPI.Response.Users;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Users.
        /// </summary>
        /// <returns>List with all Users.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetUsersResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetUsersRequest request)
        {
            try
            {
                var users = await _mediator.Send(new GetUsersQuery
                {
                    
                });

                if (!users.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetUsersResponse>>(users));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get User by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired User.</param>
        /// <returns>Info about User with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserQuery { Id = id } );

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetUserResponse>(user));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new User.
        /// </summary>
        /// <param name="user">The body of new User.</param>
        /// <returns>Info about created User.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var userSend = await _mediator.Send(_mapper.Map<CreateUserCommand>(user));
                return Created($"api/users/{userSend.Id}", _mapper.Map<CreateUserResponse>(userSend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing User.
        /// </summary>
        /// <param name="user">The body of new User.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userSend = await _mediator.Send(_mapper.Map<UpdateUserCommand>(user));
                if (userSend == null)
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
        /// Delete existing User.
        /// </summary>
        /// <param name="id">The ID of the desired User.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userSend = await _mediator.Send(new DeleteUserCommand{ Id = id });
                if (userSend == null)
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