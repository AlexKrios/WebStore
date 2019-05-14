﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Payments;
using CQS.Queries.Payments;
using WebStoreAPI.Requests.Payments;
using WebStoreAPI.Response.Payments;
using WebStoreAPI.Specifications.Payments;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Payments.
        /// </summary>
        /// <returns>List with all Payments.</returns>
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
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetPaymentsResponse>>(payments));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Payment by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Payment.</param>
        /// <returns>Info about Payment with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetPaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var payment = await _mediator.Send(new GetPaymentQuery { Id = id } );

                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetPaymentResponse>(payment));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Payment.
        /// </summary>
        /// <param name="payment">The body of new Payment.</param>
        /// <returns>Info about created Payment.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreatePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreatePaymentRequest payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var paymentSend = await _mediator.Send(_mapper.Map<CreatePaymentCommand>(payment));
                return Created($"api/payments/{paymentSend.Id}", _mapper.Map<CreatePaymentResponse>(paymentSend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Payment.
        /// </summary>
        /// <param name="payment">The body of new Payment.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdatePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdatePaymentRequest payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var paymentSend = await _mediator.Send(_mapper.Map<UpdatePaymentCommand>(payment));
                if (paymentSend == null)
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
        /// Delete existing Payment.
        /// </summary>
        /// <param name="id">The ID of the desired Payment.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeletePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var paymentSend = await _mediator.Send(new DeletePaymentCommand { Id = id });
                if (paymentSend == null)
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