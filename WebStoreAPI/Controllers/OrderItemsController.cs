using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIModels.Requests.OrderItems;
using APIModels.Response.OrderItems;
using AutoMapper;
using CQS.Commands.OrderItems;
using CQS.Queries.OrderItems;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all OrdersItems.
        /// </summary>
        /// <returns>List with all OrdersItems.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetOrdersItemsResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetOrdersItemsRequest filter)
        {
            try
            {
                var ordersItems = await _mediator.Send(new GetOrdersItemsQuery(filter));

                if (!ordersItems.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetOrdersItemsResponse>>(ordersItems));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get OrderItems by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired OrderItems.</param>
        /// <returns>Info about OrderItems with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var orderItems = await _mediator.Send(new GetOrderItemsQuery { Id = id } );

                if (orderItems == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetOrderItemsResponse>(orderItems));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new OrderItems.
        /// </summary>
        /// <param name="orderItem">The body of new OrderItems.</param>
        /// <returns>Info about created OrderItems.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateOrderItemsRequest orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderItemSend = await _mediator.Send(_mapper.Map<CreateOrderItemsCommand>(orderItem));
                return Created($"api/orderitems/{orderItemSend.Id}", _mapper.Map<CreateOrderItemsResponse>(orderItemSend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing OrderItems.
        /// </summary>
        /// <param name="orderItem">The body of new OrderItems.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateOrderItemsRequest orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderItemSend = await _mediator.Send(_mapper.Map<UpdateOrderItemsCommand>(orderItem));
                if (orderItemSend == null)
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

        /// <summary>
        /// Delete existing OrderItems.
        /// </summary>
        /// <param name="id">The ID of the desired OrderItems.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderItemSend = await _mediator.Send(new DeleteOrderItemsCommand { Id = id });
                if (orderItemSend == null)
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