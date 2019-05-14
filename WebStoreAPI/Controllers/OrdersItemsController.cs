using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.OrdersItems;
using CQS.Queries.OrdersItems;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.OrdersItems;
using WebStoreAPI.Response.OrdersItems;
using WebStoreAPI.Specifications.OrderItems;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersItemsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersItemsController> _logger;

        public OrdersItemsController(IMediator mediator, IMapper mapper, ILogger<OrdersItemsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all OrdersItems.
        /// </summary>
        /// <returns>List with all OrdersItems.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetOrdersItemsResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetOrdersItemsRequest request)
        {
            try
            {
                var minCountSpec = new OrderItemsMinCountSpecification(request.MinCount);
                var maxCountSpec = new OrderItemsMaxCountSpecification(request.MaxCount);
                var minPriceSpec = new OrderItemsMinPriceSpecification(request.MinPrice);
                var maxPriceSpec = new OrderItemsMaxPriceSpecification(request.MaxPrice);
                var productIdSpec = new OrderItemsProductIdSpecification(request.ProductId);
                var orderIdSpec = new OrderItemsOrderIdSpecification(request.OrderId);

                var specification = 
                    minCountSpec && maxCountSpec && minPriceSpec && maxPriceSpec && productIdSpec && orderIdSpec;

                var ordersItems = await _mediator.Send(new GetOrdersItemsQuery { Specification = specification });

                if (!ordersItems.Any())
                {
                    _logger.LogError("GET ORDERSITEMS - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ORDERSITEMS - Complete");
                return Ok(_mapper.Map<IEnumerable<GetOrdersItemsResponse>>(ordersItems));
            }
            catch (Exception e)
            {
                _logger.LogError(@"GET ORDERSITEMS - {0}", e);
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get OrdersItems by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired OrdersItems.</param>
        /// <returns>Info about OrdersItems with selected Id.</returns>
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
                    _logger.LogError("GET ORDERITEMS - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ORDERITEMS - Complete");
                return Ok(_mapper.Map<GetOrderItemsResponse>(orderItems));
            }
            catch (Exception e)
            {
                _logger.LogError(@"GET ORDERITEMS - {0}", e);
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new OrdersItems.
        /// </summary>
        /// <param name="orderItem">The body of new OrdersItems.</param>
        /// <returns>Info about created OrdersItems.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateOrderItemsRequest orderItem)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("POST ORDERITEMS - Not valid model");
                return BadRequest(ModelState);
            }

            try
            {
                var orderItemSend = await _mediator.Send(_mapper.Map<CreateOrderItemsCommand>(orderItem));
                _logger.LogInformation("POST ORDERITEMS - Complete, with id: " + orderItemSend.Id);
                return Created($"api/orderitems/{orderItemSend.Id}", _mapper.Map<CreateOrderItemsResponse>(orderItemSend));
            }
            catch (Exception e)
            {
                _logger.LogError(@"POST ORDERITEMS - {0}", e);
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing OrdersItems.
        /// </summary>
        /// <param name="orderItem">The body of new OrdersItems.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateOrderItemsRequest orderItem)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("UPDATE ORDERITEMS - Not valid model");
                return BadRequest(ModelState);
            }

            try
            {
                var orderItemSend = await _mediator.Send(_mapper.Map<UpdateOrderItemsCommand>(orderItem));
                if (orderItemSend == null)
                {
                    _logger.LogError("UPDATE ORDERITEMS - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE ORDERITEMS - Complete, with id: " + orderItemSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(@"UPDATE ORDERITEMS - {0}", e);
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing OrdersItems.
        /// </summary>
        /// <param name="id">The ID of the desired OrdersItems.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var orderItemSend = await _mediator.Send(new DeleteOrderItemsCommand { Id = id });
                if (orderItemSend == null)
                {
                    _logger.LogError("DELETE ORDERITEMS - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE ORDERITEMS - Complete, with id: " + orderItemSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(@"DELETE ORDERITEMS - {0}", e);
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}