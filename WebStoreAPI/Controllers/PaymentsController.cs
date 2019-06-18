using AutoMapper;
using CQS.Commands.Payments;
using CQS.Queries.Payments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStoreAPI.Requests.Payments;
using WebStoreAPI.Response.Payments;
using WebStoreAPI.Specifications.Payments;

namespace WebStoreAPI.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Payments controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IMediator mediator, IMapper mapper, ILogger<PaymentsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Payments
        /// </summary>
        /// <returns>List with all Payments</returns>
        /// <responce code="200">Get Payments by filter</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Payments not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetPaymentsResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetPaymentsRequest request)
        {
            try
            {
                var nameSpec = new PaymentNameSpecification(request.Name);
                var minTaxesSpec = new PaymentMinTaxesSpecification(request.MinTaxes);
                var maxTaxesSpec = new PaymentMaxTaxesSpecification(request.MaxTaxes);

                var specification = nameSpec && minTaxesSpec && maxTaxesSpec;

                var payments = await _mediator.Send(new GetPaymentsQuery { Specification = specification });

                if (!payments.Any())
                {
                    _logger.LogInformation("GET PAYMENTS, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET PAYMENTS, CONTROLLER - Complete");
                return Ok(_mapper.Map<IEnumerable<GetPaymentsResponse>>(payments));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PAYMENTS, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Payment by their ID
        /// </summary>
        /// <param name="id">The ID of the desired Payment</param>
        /// <returns>Info about Payment with selected Id</returns>
        /// <responce code="200">Get Payment by Id</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Payment not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetPaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var payment = await _mediator.Send(new GetPaymentQuery { Id = id });

                if (payment == null)
                {
                    _logger.LogInformation("GET PAYMENT, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET PAYMENT, CONTROLLER - Complete");
                return Ok(_mapper.Map<GetPaymentResponse>(payment));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PAYMENT, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Payment
        /// </summary>
        /// <param name="payment">The body of new Payment</param>
        /// <returns>Info about created Payment.</returns>
        /// <responce code="200">Create Payment</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreatePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreatePaymentRequest payment)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("CREATE PAYMENT, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var paymentSend = await _mediator.Send(_mapper.Map<CreatePaymentCommand>(payment));
                _logger.LogInformation("CREATE PAYMENT, CONTROLLER - Complete, with id: " + paymentSend.Id);
                return Created($"api/payments/{paymentSend.Id}", _mapper.Map<CreatePaymentResponse>(paymentSend));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE PAYMENT, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Payment
        /// </summary>
        /// <param name="payment">The body of new Payment</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Update Payment</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Payment not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdatePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdatePaymentRequest payment)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("UPDATE PAYMENT, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var paymentSend = await _mediator.Send(_mapper.Map<UpdatePaymentCommand>(payment));
                if (paymentSend == null)
                {
                    _logger.LogInformation("UPDATE PAYMENT, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE PAYMENT, CONTROLLER - Complete, with id: " + paymentSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE PAYMENT, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing Payment
        /// </summary>
        /// <param name="id">The ID of the desired Payment</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Delete Payment</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Payment not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeletePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var paymentSend = await _mediator.Send(new DeletePaymentCommand { Id = id });
                if (paymentSend == null)
                {
                    _logger.LogInformation("DELETE PAYMENT, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE PAYMENT, CONTROLLER - Complete, with id: " + paymentSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE PAYMENT, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}