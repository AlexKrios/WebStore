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
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        //Get single user
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _mediator.Send(new GetSingleUserQuery(id));
        }

        //Get group of user
        [HttpGet("role/{role}")]
        public async Task<IEnumerable<User>> GetGroup(string role)
        {
            return await _mediator.Send(new GetGroupUsersQuery(role));
        }

        //Add new user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            await _mediator.Send(new PostUserCommand(user));
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            await _mediator.Send(new PutUserCommand(user));
            return Ok(user);
        }

        //Delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _mediator.Send(new GetSingleUserQuery(id));

            await _mediator.Send(new DeleteUserCommand(user));
            return Ok(user);
        }
    }
}