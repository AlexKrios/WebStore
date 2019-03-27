using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands.Products;
using WebStoreAPI.Models;
using WebStoreAPI.Queries.Products;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of products
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        //Get single product
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _mediator.Send(new GetSingleProductQuery(id));
        }

        //Get group of products
        [HttpGet("group/{type}")]
        public async Task<IEnumerable<Product>> GetGroup(string type)
        {
            return await _mediator.Send(new GetGroupProductsQuery(type));
        }

        //Add new product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            //await _commandDispatcher.Execute(new PostProductCommand(product));
            await _mediator.Send(new PostProductCommand(product));
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Product product)
        {
            await _mediator.Send(new PutProductCommand(product));
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _mediator.Send(new GetSingleProductQuery(id));

            await _mediator.Send(new DeleteProductCommand(product));
            return Ok(product);
        }
    }
}
