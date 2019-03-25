using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands;
using WebStoreAPI.Commands.ProductsFolder.Handlers;
using WebStoreAPI.Models;
using WebStoreAPI.Queries;
using WebStoreAPI.Queries.ProductsFolder.Handlers;

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
            return _queryDispatcher.Dispatch<GetAllProductsHandler, IEnumerable<Product>>();
        }

        //Get single product
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _queryDispatcher.Dispatch<GetProductHandler, Product>(id);
        }

        //Get group of products
        [HttpGet("group/{type}")]
        public IEnumerable<Product> GetGroup(string type)
        {
            return _queryDispatcher.Dispatch<GetGroupProductsHandler, IEnumerable<Product>>(type);
        }

        //Add new product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _commandDispatcher.Dispatch<PostProductHandler, Product>(product);
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            _commandDispatcher.Dispatch<PutProductHandler, Product>(product);
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _queryDispatcher.Dispatch<GetProductHandler, Product>(id);

            _commandDispatcher.Dispatch<DeleteProductHandler, Product>(product);
            return Ok(product);
        }
    }
}
