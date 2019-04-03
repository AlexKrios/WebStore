using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Commands.Products;
using WebStoreAPI.Models;
using WebStoreAPI.Queries.Products;
using System.Linq;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly WebStoreContext _context;

        //Setup connection
        public ProductsController(IMediator mediator, WebStoreContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        //Get list of products
        [HttpGet("getAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery());

                if (!products.Any())
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Get single product
        [HttpGet("getById/{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery(id));

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get group of products
        [HttpGet("getByType/{type}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetProductByType(string type)
        {
            try
            {
                var products = await _mediator.Send(new GetProductsByTypeQuery(type));

                if (!products.Any())
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new product
        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(CreateProductCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateProductCommand product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change product
        [HttpPut("update")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateProductCommand product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Products.Any(x => x.Id == product.Id))
            {
                return NotFound();
            }

            try
            {
                await _mediator.Send(product);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Delete product 
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Products.Any(x => x.Id == id))
            {
                return NotFound();
            }

            try
            {
                await _mediator.Send(new DeleteProductCommand(id));
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}
