using System;
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
        [HttpGet("getAll")]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        //Get single product
        [HttpGet("getById/{id}")]
        public async Task<Product> GetById(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        //Get group of products
        [HttpGet("getByType/{type}")]
        public async Task<IEnumerable<Product>> GetProductByType(string type)
        {
            return await _mediator.Send(new GetProductsByTypeQuery(type));
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
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
    }
}
