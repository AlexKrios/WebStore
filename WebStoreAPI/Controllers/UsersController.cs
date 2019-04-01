using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands.Users;
using WebStoreAPI.Models;
using WebStoreAPI.Queries.Users;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of users
        [HttpGet("getAll")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        //Get single user
        [HttpGet("getById/{id}")]
        public async Task<User> GetById(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        //Get group of user
        [HttpGet("getByRole/{role}")]
        public async Task<IEnumerable<User>> GetUserByRole(string role)
        {
            return await _mediator.Send(new GetUsersByRoleQuery(role));
        }

        //Add new user
        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateUserCommand(user));
            return Ok(user);
        }

        //Change user
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateUserCommand(user));
            return Ok();
        }

        //Delete user
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
    }
}