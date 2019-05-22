using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Deliveries;
using CQS.Queries.Deliveries;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.Deliveries;
using WebStoreAPI.Response.Deliveries;
using WebStoreAPI.Specifications.Deliveries;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<DeliveriesController> _logger;

        public DeliveriesController(IMediator mediator, IMapper mapper, ILogger<DeliveriesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Deliveries.
        /// </summary>
        /// <returns>List with all Deliveries.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetDeliveriesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery] GetDeliveriesRequest request)
        {
            try
            {
                var nameSpec = new DeliveryNameSpecification(request.Name);
                var minPriceSpec = new DeliveryMinPriceSpecification(request.MinPrice);
                var maxPriceSpec = new DeliveryMaxPriceSpecification(request.MaxPrice);
                var minRatingSpec = new DeliveryMinRatingSpecification(request.MinRating);
                var maxRatingSpec = new DeliveryMaxRatingSpecification(request.MaxRating);
                
                var specification =  nameSpec && minPriceSpec && maxPriceSpec && minRatingSpec && maxRatingSpec;

                var deliveries = await _mediator.Send(new GetDeliveriesQuery { Specification = specification });

                if (!deliveries.Any())
                {
                    _logger.LogError("GET DELIVERIES - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET DELIVERIES - Complete");
                return Ok(_mapper.Map<IEnumerable<GetDeliveriesResponse>>(deliveries));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET DELIVERIES - {e}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Get Delivery by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Delivery.</param>
        /// <returns>Info about Delivery with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetDeliveryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var delivery = await _mediator.Send(new GetDeliveryQuery {Id = id});

                if (delivery == null)
                {
                    _logger.LogError("GET DELIVERY - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET DELIVERY - Complete");
                return Ok(_mapper.Map<GetDeliveryResponse>(delivery));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET DELIVERY - {e}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Create a new Delivery.
        /// </summary>
        /// <param name="delivery">The body of new Delivery.</param>
        /// <returns>Info about created Delivery.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateDeliveryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateDeliveryRequest delivery)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("POST DELIVERY - Not valid");
                return BadRequest();
            }

            try
            {
                var deliverySend = await _mediator.Send(_mapper.Map<CreateDeliveryCommand>(delivery));
                _logger.LogInformation("POST DELIVERY - Complete, with id: " + deliverySend.Id);
                return Created($"api/deliveries/{deliverySend.Id}", _mapper.Map<CreateDeliveryResponse>(deliverySend));
            }
            catch (Exception e)
            {
                _logger.LogError($"POST DELIVERY - {e}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Update existing Delivery.
        /// </summary>
        /// <param name="delivery">The body of new Delivery.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateDeliveryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateDeliveryRequest delivery)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("PUT DELIVERY - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var deliverySend = await _mediator.Send(_mapper.Map<UpdateDeliveryCommand>(delivery));
                if (deliverySend == null)
                {
                    _logger.LogError("PUT DELIVERY - Not found");
                    return NotFound();
                }

                _logger.LogInformation("PUT DELIVERY - Complete, with id: " + deliverySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"PUT DELIVERY - {e}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Delete existing Delivery.
        /// </summary>
        /// <param name="id">The ID of the desired Delivery.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteDeliveryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deliverySend = await _mediator.Send(new DeleteDeliveryCommand {Id = id});
                if (deliverySend == null)
                {
                    _logger.LogError("DELETE DELIVERY - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE DELIVERY - Complete, with id: " + deliverySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"DELETE DELIVERY - {e}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}