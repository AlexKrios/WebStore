using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.OrderItems;
using CQS.Queries.OrderItems;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.OrderItems;
using WebStoreAPI.Response.OrderItems;
using WebStoreAPI.Specifications.OrderItems;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderItemsController> _logger;

        public OrderItemsController(IMediator mediator, IMapper mapper, ILogger<OrderItemsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all OrderItem.
        /// </summary>
        /// <returns>List with all OrderItem.</returns>
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
                _logger.LogError($"GET ORDERSITEMS - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get OrderItem by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired OrderItem.</param>
        /// <returns>Info about OrderItem with selected Id.</returns>
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
                _logger.LogError($"GET ORDERITEMS - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new OrderItem.
        /// </summary>
        /// <param name="orderItem">The body of new OrderItem.</param>
        /// <returns>Info about created OrderItem.</returns>
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
                _logger.LogError($"POST ORDERITEMS - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing OrderItem.
        /// </summary>
        /// <param name="orderItem">The body of new OrderItem.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderItemsResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateOrderItemsRequest orderItem)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("PUT ORDERITEMS - Not valid model");
                return BadRequest(ModelState);
            }

            try
            {
                var orderItemSend = await _mediator.Send(_mapper.Map<UpdateOrderItemsCommand>(orderItem));
                if (orderItemSend == null)
                {
                    _logger.LogError("PUT ORDERITEMS - Not found");
                    return NotFound();
                }

                _logger.LogInformation("PUT ORDERITEMS - Complete, with id: " + orderItemSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"PUT ORDERITEMS - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing OrderItem.
        /// </summary>
        /// <param name="id">The ID of the desired OrderItem.</param>
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
                _logger.LogError($"DELETE ORDERITEMS - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}