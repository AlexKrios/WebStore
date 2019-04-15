using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Users;
using CQS.Queries.Users;
using WebStoreAPI.Response.Users;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of users
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetUsersResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _mediator.Send(new GetUsersQuery());

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

        //Get single user
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

        //Get group of user
        //[HttpGet("{role}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        //[ProducesResponseType(500, Type = typeof(string))]
        //public async Task<IActionResult> GetUserByRole(string role)
        //{
        //    try
        //    {
        //        var users = await _mediator.Send(new GetUsersByRoleQuery(role));

        //        if (!users.Any())
        //        {
        //            return NotFound();
        //        }

        //        return Ok(users);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, new { errorMessage = e.Message });
        //    }
        //}

        //Add new user
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserCommand user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var userSend = await _mediator.Send(user);
                return Created($"api/users/{userSend.Id}", _mapper.Map<CreateUserResponse>(user));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change user
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserCommand user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userSend = await _mediator.Send(user);
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

        //Delete user
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