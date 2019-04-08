using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using WebStoreAPI.Commands.Products;
using WebStoreAPI.Queries.Products;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public ProductsController(IMediator mediator, WebStoreContext context)
        {
            _mediator = mediator;
            DbInit.Init(context);
        }

        //Get list of products
        [HttpGet]
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
        [HttpGet("{id}")]
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
        //[HttpGet("{type}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        //[ProducesResponseType(500, Type = typeof(string))]
        //public async Task<IActionResult> GetProductByType(string type)
        //{
        //    try
        //    {
        //        var products = await _mediator.Send(new GetProductsByTypeQuery(type));

        //        if (!products.Any())
        //        {
        //            return NotFound();
        //        }

        //        return Ok(products);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, new { errorMessage = e.Message });
        //    }
        //}

        //Add new product
        [HttpPost]
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
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateProductCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateProductCommand product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(product);
                if (productSend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Delete product 
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(new DeleteProductCommand(id));
                if (productSend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}