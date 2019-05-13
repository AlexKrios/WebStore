﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Products;
using CQS.Queries.Products;
using WebStoreAPI.Requests.Products;
using WebStoreAPI.Response.Products;
using WebStoreAPI.Specifications.Products;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Products.
        /// </summary>
        /// <returns>List with all Products.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetProductsResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetProductsRequest request)
        {
            try
            {
                var nameSpec = new ProductNameSpecification(request.Name);
                var minAvailabilitySpec = new ProductMinAvailabilitySpecification(request.MinAvailability);
                var maxAvailabilitySpec = new ProductMaxAvailabilitySpecification(request.MaxAvailability);
                var minPriceSpec = new ProductMinPriceSpecification(request.MinPrice);
                var maxPriceSpec = new ProductMaxPriceSpecification(request.MaxPrice);
                var typeIdSpec = new ProductTypeIdSpecification(request.TypeId);
                var manufacturerIdSpec = new ProductManufacturerIdSpecification(request.ManufacturerId);

                var specification = nameSpec && minAvailabilitySpec && maxAvailabilitySpec &&
                                    minPriceSpec && maxPriceSpec && typeIdSpec && manufacturerIdSpec;

                var products = await _mediator.Send(new GetProductsQuery
                {
                    Specification = specification
                });

                if (!products.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetProductResponse>>(products));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Get Product by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Product.</param>
        /// <returns>Info about Product with selected Id.</returns>
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

        /// <summary>
        /// Create a new Product.
        /// </summary>
        /// <param name="product">The body of new Product.</param>
        /// <returns>Info about created Product.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateProductResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateProductRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(_mapper.Map<CreateProductCommand>(product));
                return Created($"api/products/{productSend.Id}", _mapper.Map<CreateProductResponse>(productSend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Update existing Product.
        /// </summary>
        /// <param name="product">The body of new Product.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateProductResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateProductRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(_mapper.Map<UpdateProductCommand>(product));
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

        /// <summary>
        /// Delete existing Product.
        /// </summary>
        /// <param name="id">The ID of the desired Product.</param>
        /// <returns>Nothing</returns>
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