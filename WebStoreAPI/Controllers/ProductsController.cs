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
        private readonly IQueriesService<Product> queries;
        private readonly ICommandService<Product> commands;

        //Setup connection
        public ProductsController(ICommandService<Product> commands, IQueriesService<Product> queries)
        {
            this.commands = commands ?? throw new ArgumentNullException(nameof(commands));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        //Get list of products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this.queries.GetAll();
        }

        //Get single product
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = this.queries.GetSingle(id);
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
            return this.queries.GetGroup(type);
        }

        //Add new product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            this.commands.Post(product);
            this.commands.SaveDb();
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            this.commands.Put(product);
            this.commands.SaveDb();
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = this.queries.GetSingle(id);
            this.commands.Delete(product);
            this.commands.SaveDb();
            return Ok(product);
        }
    }
}
