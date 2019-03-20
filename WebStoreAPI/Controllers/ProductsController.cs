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
    public class ProductsController : Controller
    {
        private readonly IQueriesService<Product> _queries;
        private readonly ICommandService<Product> _commands;

        //Setup connection
        public ProductsController(ICommandService<Product> commands, IQueriesService<Product> queries)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        //Get list of products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _queries.GetAll();
        }

        //Get single product
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _queries.GetSingle(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Get group of products
        [HttpGet("group/{type}")]
        public IEnumerable<Product> GetGroup(string type)
        {
            return _queries.GetGroup(type);
        }

        //Add new product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _commands.Post(product);
            _commands.SaveDb();
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            _commands.Put(product);
            _commands.SaveDb();
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _queries.GetSingle(id);
            _commands.Delete(product);
            _commands.SaveDb();
            return Ok(product);
        }
    }
}
