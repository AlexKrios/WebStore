using AutoMapper;
using CQS.Commands.Products;
using CQS.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IMediator mediator, IMapper mapper, ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
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
                var manufacturerIdSpec = new ProductManufacturerIdSpecification(request.ManufacturerId);

                var specification = nameSpec && minAvailabilitySpec && maxAvailabilitySpec &&
                                    minPriceSpec && maxPriceSpec && manufacturerIdSpec;

                var products = await _mediator.Send(new GetProductsQuery { Specification = specification });

                if (!products.Any())
                {
                    _logger.LogInformation("GET PRODUCTS, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET PRODUCTS, CONTROLLER - Complete");
                return Ok(_mapper.Map<IEnumerable<GetProductResponse>>(products));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PRODUCTS, CONTROLLER - {e.Message}");
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
                    _logger.LogInformation("GET PRODUCT, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET PRODUCT, CONTROLLER - Complete");
                return Ok(_mapper.Map<GetProductResponse>(product));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PRODUCT, CONTROLLER - {e.Message}");
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
                _logger.LogError("CREATE PRODUCT, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(_mapper.Map<CreateProductCommand>(product));
                _logger.LogInformation("CREATE PRODUCT, CONTROLLER - Complete, with id: " + productSend.Id);
                return Created($"api/products/{productSend.Id}", _mapper.Map<CreateProductResponse>(productSend));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE PRODUCT, CONTROLLER - {e.Message}");
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
                _logger.LogError("UPDATE PRODUCT, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var productSend = await _mediator.Send(_mapper.Map<UpdateProductCommand>(product));
                if (productSend == null)
                {
                    _logger.LogInformation("UPDATE PRODUCT, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE PRODUCT, CONTROLLER - Complete, with id: " + productSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE PRODUCT, CONTROLLER - {e.Message}");
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
            try
            {
                var productSend = await _mediator.Send(new DeleteProductCommand { Id = id });
                if (productSend == null)
                {
                    _logger.LogInformation("DELETE PRODUCT, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE PRODUCT, CONTROLLER - Complete, with id: " + productSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE PRODUCT, CONTROLLER - {e.Message}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}