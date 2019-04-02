using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands.Users;
using WebStoreAPI.Models;
using WebStoreAPI.Queries.Users;
using System.Linq;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly WebStoreContext _context;

        //Setup connection
        public UsersController(IMediator mediator, WebStoreContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        //Get list of users
        [HttpGet("getAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());

                if (!users.Any())
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //Get single user
        [HttpGet("getById/{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByIdQuery(id));

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //Get group of user
        [HttpGet("getByRole/{role}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetUserByRole(string role)
        {
            try
            {
                var users = await _mediator.Send(new GetUsersByRoleQuery(role));

                if (!users.Any())
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //Add new user
        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(CreateUserCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserCommand user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //Change user
        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserCommand user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            try
            {
                await _mediator.Send(user);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //Delete user
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Users.Any(x => x.Id == id))
            {
                return NotFound();
            }

            try
            {
                await _mediator.Send(new DeleteUserCommand(id));
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}