using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAndQuerySeparation.Commands.Deliveries;
using CommandAndQuerySeparation.Queries.Deliveries;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public DeliveriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of deliveries
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Delivery>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var deliveries = await _mediator.Send(new GetAllDeliveriesQuery());

                if (!deliveries.Any())
                {
                    return NotFound();
                }

                return Ok(deliveries);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single delivery
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Delivery))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var delivery = await _mediator.Send(new GetDeliveryByIdQuery(id));

                if (delivery == null)
                {
                    return NotFound();
                }

                return Ok(delivery);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new delivery
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateDeliveryCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateDeliveryCommand delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
                await _mediator.Send(delivery);
                return Ok(delivery);
        }

        //Change delivery
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateDeliveryCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateDeliveryCommand delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var deliverySend = await _mediator.Send(delivery);
                if (deliverySend == null)
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

        //Delete delivery
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Delivery))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var deliverySend = await _mediator.Send(new DeleteDeliveryCommand(id));
                if (deliverySend == null)
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