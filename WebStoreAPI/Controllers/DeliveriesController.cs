using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Deliveries;
using CQS.Queries.Deliveries;
using WebStoreAPI.Requests.Deliveries;
using WebStoreAPI.Response.Deliveries;
using WebStoreAPI.Specifications.Deliveries;

namespace WebStoreAPI.Controllers
{
    /// <summary>
    /// Deliveries controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DeliveriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Deliveries
        /// </summary>
        /// <returns>List with all Deliveries</returns>
        /// <responce code="200">Get Deliveries by filter</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Deliveries not found</responce>
        /// <responce code="500">Internal error</responce>
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
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetDeliveriesResponse>>(deliveries));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Get Delivery by their ID
        /// </summary>
        /// <param name="id">The ID of the desired Delivery</param>
        /// <returns>Info about Delivery with selected Id</returns>
        /// <responce code="200">Get Delivery by Id</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Delivery not found</responce>
        /// <responce code="500">Internal error</responce>
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
                    return NotFound();
                }

                return Ok(_mapper.Map<GetDeliveryResponse>(delivery));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Create a new Delivery
        /// </summary>
        /// <param name="delivery">The body of new Delivery</param>
        /// <returns>Info about created Delivery</returns>
        /// <responce code="200">Create Delivery</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateDeliveryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateDeliveryRequest delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var deliverySend = await _mediator.Send(_mapper.Map<CreateDeliveryCommand>(delivery));
                return Created($"api/deliveries/{deliverySend.Id}", _mapper.Map<CreateDeliveryResponse>(deliverySend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Update existing Delivery
        /// </summary>
        /// <param name="delivery">The body of new Delivery</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Update Delivery</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Delivery not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateDeliveryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateDeliveryRequest delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var deliverySend = await _mediator.Send(_mapper.Map<UpdateDeliveryCommand>(delivery));
                if (deliverySend == null)
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
        /// Delete existing Delivery
        /// </summary>
        /// <param name="id">The ID of the desired Delivery</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Delete Delivery</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Delivery not found</responce>
        /// <responce code="500">Internal error</responce>
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