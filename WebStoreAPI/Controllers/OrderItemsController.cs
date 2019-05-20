using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.OrderItems;
using CQS.Queries.OrderItems;
using WebStoreAPI.Requests.OrderItems;
using WebStoreAPI.Response.OrderItems;
using WebStoreAPI.Specifications.OrderItems;

namespace WebStoreAPI.Controllers
{
    /// <summary>
    /// OrderItems controller
    /// </summary>
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
        /// Get all OrderItem
        /// </summary>
        /// <returns>List with all OrderItems</returns>
        /// <responce code="200">Get OrderItems by filter</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">OrderItems not found</responce>
        /// <responce code="500">Internal error</responce>
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
        /// Get OrderItem by their ID
        /// </summary>
        /// <param name="id">The ID of the desired OrderItem</param>
        /// <returns>Info about OrderItem with selected Id</returns>
        /// <responce code="200">Get OrderItem by Id</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">OrderItem not found</responce>
        /// <responce code="500">Internal error</responce>
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
        /// Create a new OrderItem
        /// </summary>
        /// <param name="orderItem">The body of new OrderItem</param>
        /// <returns>Info about created OrderItem</returns>
        /// <responce code="200">Create OrderItem</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="500">Internal error</responce>
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
        /// Update existing OrderItem
        /// </summary>
        /// <param name="orderItem">The body of new OrderItem</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Update OrderItem</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">OrderItem not found</responce>
        /// <responce code="500">Internal error</responce>
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
        /// Delete existing OrderItem
        /// </summary>
        /// <param name="id">The ID of the desired OrderItem</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Delete OrderItem</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">OrderItem not found</responce>
        /// <responce code="500">Internal error</responce>
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