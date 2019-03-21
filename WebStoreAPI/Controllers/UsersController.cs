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
        private readonly IQueriesService<User> queries;
        private readonly ICommandService<User> commands;

        //Setup connection
        public UsersController(ICommandService<User> commands, IQueriesService<User> queries)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        //Get list of users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this.queries.GetAll();
        }

        //Get single user
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = this.queries.GetSingle(id);
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
            return this.queries.GetGroup(role);
        }

        //Add new user
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            this.commands.Post(user);
            this.commands.SaveDb();
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            this.commands.Put(user);
            this.commands.SaveDb();
            return Ok(user);
        }

        //Delete user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = this.queries.GetSingle(id);
            this.commands.Delete(user);
            this.commands.SaveDb();
            return Ok(user);
        }
    }
}