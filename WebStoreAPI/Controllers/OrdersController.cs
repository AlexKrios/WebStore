using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAndQuerySeparation.Commands.Orders;
using CommandAndQuerySeparation.Queries.Orders;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of orders
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _mediator.Send(new GetAllOrdersQuery());

                if (!orders.Any())
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single order
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderByIdQuery(id));

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new order
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateOrderCommand city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(city);
                return Ok(city);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change order
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateOrderCommand order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(order);
                if (orderSend == null)
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

        //Delete order
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(City))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(new DeleteOrderCommand(id));
                if (orderSend == null)
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