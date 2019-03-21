using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;
using WebStoreAPI.Commands;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly CommandServiceUser commands;
        private readonly QueriesServiceUser queries;

        //Setup connection
        public UsersController(Container container)
        {
            commands = container.GetInstance<CommandServiceUser>();
            queries = container.GetInstance<QueriesServiceUser>();
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
            {
                return NotFound();
            }
            return Ok(user);
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
            commands.SaveDb();
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            commands.Put(user);
            commands.SaveDb();
            return Ok(user);
        }

        //Delete user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = queries.GetSingle(id);
            commands.Delete(user);
            commands.SaveDb();
            return Ok(user);
        }
    }
}