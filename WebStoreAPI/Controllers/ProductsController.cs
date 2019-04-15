using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Products;
using CQS.Queries.Products;
using WebStoreAPI.Response.Products;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of products
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetProductsResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _mediator.Send(new GetProductsQuery());

                if (!products.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetProductsResponse>>(products));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Get single product
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetProductResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductQuery { Id = id } );

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetProductResponse>(product));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Add new product
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateProductResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateProductCommand product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(product);
                return Created($"api/products/{productSend.Id}", _mapper.Map<CreateProductResponse>(product));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Change product
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateProductResponse))]
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
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        //Delete product 
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteProductResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(new DeleteProductCommand { Id = id });
                if (productSend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}