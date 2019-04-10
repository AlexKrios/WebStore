﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAndQuerySeparation.Commands.OrderItems;
using CommandAndQuerySeparation.Queries.OrderItems;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public OrderItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of ordersItems
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderItem>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ordersItem = await _mediator.Send(new GetAllOrderItemsQuery());

                if (!ordersItem.Any())
                {
                    return NotFound();
                }

                return Ok(ordersItem);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single orderItem
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderItem))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var orderItem = await _mediator.Send(new GetOrderItemsByIdQuery(id));

                if (orderItem == null)
                {
                    return NotFound();
                }

                return Ok(orderItem);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new orderItem
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderItemsCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateOrderItemsCommand orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(orderItem);
                return Ok(orderItem);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change order
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderItemsCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateOrderItemsCommand orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderItemSend = await _mediator.Send(orderItem);
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

        //Delete order
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderItem))]
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