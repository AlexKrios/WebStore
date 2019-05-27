using AutoMapper;
using CQS.Commands.Deliveries;
using CQS.Queries.Deliveries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                    _logger.LogInformation("GET DELIVERIES, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET DELIVERIES, CONTROLLER - Complete");
                return Ok(_mapper.Map<IEnumerable<GetDeliveriesResponse>>(deliveries));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET DELIVERIES, CONTROLLER - {e.Message}");
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
                    _logger.LogInformation("GET DELIVERY, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET DELIVERY, CONTROLLER - Complete");
                return Ok(_mapper.Map<GetDeliveryResponse>(delivery));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET DELIVERY, CONTROLLER - {e.Message}");
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
                _logger.LogError("CREATE DELIVERY, CONTROLLER - Not valid");
                return BadRequest();
            }

            try
            {
                var deliverySend = await _mediator.Send(_mapper.Map<CreateDeliveryCommand>(delivery));
                _logger.LogInformation("CREATE DELIVERY, CONTROLLER - Complete, with id: " + deliverySend.Id);
                return Created($"api/deliveries/{deliverySend.Id}", _mapper.Map<CreateDeliveryResponse>(deliverySend));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE DELIVERY, CONTROLLER - {e.Message}");
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
                _logger.LogError("UPDATE DELIVERY, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var deliverySend = await _mediator.Send(_mapper.Map<UpdateDeliveryCommand>(delivery));
                if (deliverySend == null)
                {
                    _logger.LogInformation("UPDATE DELIVERY, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE DELIVERY, CONTROLLER - Complete, with id: " + deliverySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE DELIVERY, CONTROLLER - {e.Message}");
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
                    _logger.LogInformation("DELETE DELIVERY, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE DELIVERY, CONTROLLER - Complete, with id: " + deliverySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE DELIVERY, CONTROLLER - {e.Message}");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}