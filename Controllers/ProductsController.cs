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
            return queries.GetAll();
        }

        //Get single product
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return queries.GetSingle(id);
        }

        //Get group of products
        [HttpGet("group/{type}")]
        public IEnumerable<Product> GetGroup(string type)
        {
            return queries.GetGroup(type);
        }

        //Add new product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            commands.Post(product);
            commands.SaveDB();
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            commands.Put(product);
            commands.SaveDB();
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = queries.GetSingle(id);
            commands.Delete(product);
            commands.SaveDB();
            return Ok(product);
        }
    }
}
