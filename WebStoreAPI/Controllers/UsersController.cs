using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands;
using WebStoreAPI.Commands.Users;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;
using WebStoreAPI.Queries.Users;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        //Setup connection
        public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        //Get list of users
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _queryDispatcher.Execute<IEnumerable<User>, GetAllUsersQueries>(new GetAllUsersQueries());
        }

        //Get single user
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _queryDispatcher.Execute<User, GetSingleUserQueries>(new GetSingleUserQueries(id));
        }

        //Get group of user
        [HttpGet("role/{role}")]
        public async Task<IEnumerable<User>> GetGroup(string role)
        {
            return await _queryDispatcher.Execute<IEnumerable<User>, GetGroupUsersQueries>(new GetGroupUsersQueries(role));
        }

        //Add new user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            await _commandDispatcher.Execute(new PostUserCommand(user));
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            await _commandDispatcher.Execute(new PutUserCommand(user));
            return Ok(user);
        }

        //Delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _queryDispatcher.Execute<User, GetSingleUserQueries>(new GetSingleUserQueries(id));

            await _commandDispatcher.Execute(new DeleteUserCommand(user));
            return Ok(user);
        }
    }
}