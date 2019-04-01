using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
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
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            if (!users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        //Get single user
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        //Get group of user
        [HttpGet("getByRole/{role}")]
        public async Task<IActionResult> GetUserByRole(string role)
        {
            var users = await _mediator.Send(new GetUsersByRoleQuery(role));

            if (!users.Any())
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(users);
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
    }
}