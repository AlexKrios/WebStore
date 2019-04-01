using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
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
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        //Get single product
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //Get group of products
        [HttpGet("getByType/{type}")]
        public async Task<IActionResult> GetProductByType(string type)
        {
            var products = await _mediator.Send(new GetProductsByTypeQuery(type));

            if (!products.Any())
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(products);
        }

        //Add new product
        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new CreateProductCommand(product));
            return Ok(product);
        }

        //Change product
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateProductCommand(product));
            return Ok();
        }

        //Delete product 
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
    }
}
