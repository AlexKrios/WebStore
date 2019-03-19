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
            return queries.GetAll();
        }

        //Get single user
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = queries.GetSingle(id);
            if (user == null)
                return NotFound();
            return Ok(queries.GetSingle(id));
        }

        //Get group of user
        [HttpGet("role/{role}")]
        public IEnumerable<User> GetGroup(string role)
        {
            return queries.GetGroup(role);
        }

        //Add new user
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            commands.Post(user);
            commands.SaveDB();
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public IActionResult Put([FromBody]User User)
        {
            commands.Put(User);
            commands.SaveDB();
            return Ok(User);
        }

        //Delete user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = queries.GetSingle(id);
            commands.Delete(user);
            commands.SaveDB();
            return Ok(user);
        }
    }
}