using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Orders;
using CQS.Queries.Orders;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.Orders;
using WebStoreAPI.Response.Orders;
using WebStoreAPI.Specifications.Orders;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IMediator mediator, IMapper mapper, ILogger<OrdersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Orders.
        /// </summary>
        /// <returns>List with all Orders.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetOrdersResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetOrdersRequest request)
        {
            try
            {
                var minTotalPriceSpec = new OrderMinTotalPriceSpecification(request.MinTotalPrice);
                var maxTotalPriceSpec = new OrderMaxTotalPriceSpecification(request.MaxTotalPrice);
                var userIdSpec = new OrderUserIdSpecification(request.UserId);
                var deliverIdSpec = new OrderDeliveryIdSpecification(request.DeliveryId);
                var paymentIdSpec = new OrderPaymentIdSpecification(request.PaymentId);

                var specification = 
                    minTotalPriceSpec && maxTotalPriceSpec && userIdSpec && deliverIdSpec && paymentIdSpec;;

                var orders = await _mediator.Send(new GetOrdersQuery { Specification = specification });

                if (!orders.Any())
                {
                    _logger.LogError("GET ORDERS - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ORDERS - Complete");
                return Ok(_mapper.Map<IEnumerable<GetOrdersResponse>>(orders));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET ORDERS - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Order by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Order.</param>
        /// <returns>Info about Order with selected Id.</returns>
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
                    _logger.LogError("GET ORDER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ORDER - Complete");
                return Ok(_mapper.Map<GetOrderResponse>(order));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET ORDER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Order.
        /// </summary>
        /// <param name="order">The body of new Order.</param>
        /// <returns>Info about created Order.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("POST ORDER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(_mapper.Map<CreateOrderCommand>(order));
                _logger.LogInformation("POST ORDER - Complete, with id: " + orderSend.Id);
                return Created($"api/orders/{orderSend.Id}", _mapper.Map<CreateOrderResponse>(orderSend));
            }
            catch (Exception e)
            {
                _logger.LogError($"POST ORDER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Order.
        /// </summary>
        /// <param name="order">The body of new Order.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("PUT ORDER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(_mapper.Map<UpdateOrderCommand>(order));
                if (orderSend == null)
                {
                    _logger.LogError("PUT ORDER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("PUT ORDER - Complete, with id: " + orderSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"PUT ORDER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing Order.
        /// </summary>
        /// <param name="id">The ID of the desired Order.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var orderSend = await _mediator.Send(new DeleteOrderCommand { Id = id });
                if (orderSend == null)
                {
                    _logger.LogError("DELETE ORDER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE ORDER - Complete, with id: " + orderSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"DELETE ORDER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}