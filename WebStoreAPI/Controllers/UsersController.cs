using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;
using WebStoreAPI.Queries.UsersFolder;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        //private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        //Setup connection
        public UsersController(/*CommandDispatcher commandDispatcher, */QueryDispatcher queryDispatcher)
        {
            //_commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        //Get list of users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _queryDispatcher.Dispatch<GetAllUsersHandler, IEnumerable<User>>();
        }

        //Get single user
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _queryDispatcher.Dispatch<GetUserHandler, User>(id);
        }

        //Get group of user
        [HttpGet("role/{role}")]
        public IEnumerable<User> GetGroup(string role)
        {
            return _queryDispatcher.Dispatch<GetGroupUsersHandler, IEnumerable<User>>(role);
        }

        //Add new user
        /*[HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _commandDispatcher.Dispatch<PostUserHandler>(user);
            _commandDispatcher.Dispatch<SaveUserHandler>();
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            _commandDispatcher.Dispatch<PutProductHandler>(user);
            _commandDispatcher.Dispatch<SaveProductHandler>();
            return Ok(user);
        }

        //Delete user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _queryDispatcher.Dispatch<GetUserHandler, User>(id);

            _commandDispatcher.Dispatch<DeleteUserHandler>(user);
            _commandDispatcher.Dispatch<SaveProductHandler>();
            return Ok(user);
        }*/
    }
}