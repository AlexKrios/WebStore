using AutoMapper;
using CQS.Commands.Orders;
using CQS.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStoreAPI.Requests.Orders;
using WebStoreAPI.Response.Orders;
using WebStoreAPI.Specifications.Orders;

namespace WebStoreAPI.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Orders controller
    /// </summary>
    [Authorize]
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
        /// Get all Orders
        /// </summary>
        /// <returns>List with all Orders</returns>
        /// <responce code="200">Get Orders by filter</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Orders not found</responce>
        /// <responce code="500">Internal error</responce>
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
                    minTotalPriceSpec && maxTotalPriceSpec && userIdSpec && deliverIdSpec && paymentIdSpec;

                var orders = await _mediator.Send(new GetOrdersQuery { Specification = specification });

                if (!orders.Any())
                {
                    _logger.LogInformation("GET ORDERS, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ORDERS, CONTROLLER - Complete");
                return Ok(_mapper.Map<IEnumerable<GetOrdersResponse>>(orders));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ORDERS, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Order by their ID
        /// </summary>
        /// <param name="id">The ID of the desired Order</param>
        /// <returns>Info about Order with selected Id</returns>
        /// <responce code="200">Get Order by Id</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Order not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderQuery { Id = id });

                if (order == null)
                {
                    _logger.LogInformation("GET ORDER, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET ORDER, CONTROLLER - Complete");
                return Ok(_mapper.Map<GetOrderResponse>(order));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ORDER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="order">The body of new Order</param>
        /// <returns>Info about created Order</returns>
        /// <responce code="200">Create Order</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("CREATE ORDER, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(_mapper.Map<CreateOrderCommand>(order));
                _logger.LogInformation("CREATE ORDER, CONTROLLER - Complete, with id: " + orderSend.Id);
                return Created($"api/orders/{orderSend.Id}", _mapper.Map<CreateOrderResponse>(orderSend));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE ORDER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Order
        /// </summary>
        /// <param name="order">The body of new Order</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Update Order</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Order not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateOrderResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("UPDATE ORDER, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var orderSend = await _mediator.Send(_mapper.Map<UpdateOrderCommand>(order));
                if (orderSend == null)
                {
                    _logger.LogInformation("UPDATE ORDER, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE ORDER, CONTROLLER - Complete, with id: " + orderSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE ORDER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing Order
        /// </summary>
        /// <param name="id">The ID of the desired Order</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Delete Order</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Order not found</responce>
        /// <responce code="500">Internal error</responce>
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
                    _logger.LogInformation("DELETE ORDER, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE ORDER, CONTROLLER - Complete, with id: " + orderSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE ORDER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}