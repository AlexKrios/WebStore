using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands.Users;
using WebStoreAPI.Mapper;
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
                Console.WriteLine(e);
                throw;
            }
        }

        //Get single user
        [HttpGet("getById/{id}")]
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
                Console.WriteLine(e);
                throw;
            }
        }

        //Get group of user
        [HttpGet("getByRole/{role}")]
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
                Console.WriteLine(e);
                throw;
            }
        }

        //Add new user
        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody]UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(new CreateUserCommand(userDto));
                return Ok(userDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Change user
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]User user)
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
                await _mediator.Send(new UpdateUserCommand(user));
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Delete user
        [HttpDelete("delete/{id}")]
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}