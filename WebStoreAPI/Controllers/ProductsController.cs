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
    public class ProductsController : Controller
    {
        private readonly CommandServiceProduct commands;
        private readonly QueriesServiceProduct queries;

        //Setup connection
        public ProductsController(Container container)
        {
            commands = container.GetInstance<CommandServiceProduct>();
            queries = container.GetInstance<QueriesServiceProduct>();
        }

        //Get list of products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return queries.GetAll();
        }

        //Get single product
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = queries.GetSingle(id);
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
            return queries.GetGroup(type);
        }

        //Add new product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            commands.Post(product);
            commands.SaveDb();
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            commands.Put(product);
            commands.SaveDb();
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = queries.GetSingle(id);
            commands.Delete(product);
            commands.SaveDb();
            return Ok(product);
        }
    }
}
