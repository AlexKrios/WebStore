using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands;
using WebStoreAPI.Commands.Products;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;
using WebStoreAPI.Queries.Products;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        //Setup connection
        public ProductsController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        //Get list of products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _queryDispatcher.Execute<IEnumerable<Product>, GetAllProductsCommand>(new GetAllProductsCommand());
        }

        //Get single product
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _queryDispatcher.Execute<Product, GetSingleProductCommand>(new GetSingleProductCommand(id));
        }

        //Get group of products
        [HttpGet("group/{type}")]
        public IEnumerable<Product> GetGroup(string type)
        {
            return _queryDispatcher.Execute<IEnumerable<Product>, GetGroupProductsCommand>(new GetGroupProductsCommand(type));
        }

        //Add new product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _commandDispatcher.Execute(new PostProductCommand(product));
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            _commandDispatcher.Execute(new PutProductCommand(product));
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _queryDispatcher.Execute<Product, GetSingleProductCommand>(new GetSingleProductCommand(id));

            _commandDispatcher.Execute(new DeleteProductCommand(product));
            return Ok(product);
        }
    }
}
