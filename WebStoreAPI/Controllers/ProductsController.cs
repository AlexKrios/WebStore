using System.Collections.Generic;
using System.Threading.Tasks;
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
        public ProductsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        //Get list of products
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _queryDispatcher.Execute<IEnumerable<Product>, GetAllProductsQueries>(new GetAllProductsQueries());
        }

        //Get single product
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _queryDispatcher.Execute<Product, GetSingleProductQueries>(new GetSingleProductQueries(id));
        }

        //Get group of products
        [HttpGet("group/{type}")]
        public async Task<IEnumerable<Product>> GetGroup(string type)
        {
            return await _queryDispatcher.Execute<IEnumerable<Product>, GetGroupProductsQueries>(new GetGroupProductsQueries(type));
        }

        //Add new product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            await _commandDispatcher.Execute(new PostProductCommand(product));
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Product product)
        {
            await _commandDispatcher.Execute(new PutProductCommand(product));
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _queryDispatcher.Execute<Product, GetSingleProductQueries>(new GetSingleProductQueries(id));

            await _commandDispatcher.Execute(new DeleteProductCommand(product));
            return Ok(product);
        }
    }
}
