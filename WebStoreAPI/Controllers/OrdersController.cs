﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Orders;
using CQS.Queries.Orders;
using WebStoreAPI.Response.Orders;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of orders
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetOrdersResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _mediator.Send(new GetOrdersQuery());

                if (!orders.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetOrdersResponse>>(orders));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single order
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderQuery { Id = id } );

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetOrderResponse>(order));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new order
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateOrderCommand order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(order);
                return Created($"api/orders/{orderSend.Id}", _mapper.Map<CreateOrderResponse>(order));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change order
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderResponse))]
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
        [ProducesResponseType(200, Type = typeof(DeleteOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(new DeleteOrderCommand { Id = id });
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