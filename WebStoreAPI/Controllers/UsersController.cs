using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IQueriesService<User> _queries;
        private readonly ICommandService<User> _commands;

        //Setup connection
        public UsersController(ICommandService<User> commands, IQueriesService<User> queries)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        //Get list of users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _queries.GetAll();
        }

        //Get single user
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _queries.GetSingle(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Get group of user
        [HttpGet("role/{role}")]
        public IEnumerable<User> GetGroup(string role)
        {
            return _queries.GetGroup(role);
        }

        //Add new user
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _commands.Post(user);
            _commands.SaveDb();
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            _commands.Put(user);
            _commands.SaveDb();
            return Ok(user);
        }

        //Delete user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _queries.GetSingle(id);
            _commands.Delete(user);
            _commands.SaveDb();
            return Ok(user);
        }
    }
}