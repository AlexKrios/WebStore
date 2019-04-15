using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Payments;
using CQS.Queries.Payments;
using WebStoreAPI.Response.Payments;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public PaymentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of payments
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetPaymentsResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var payments = await _mediator.Send(new GetPaymentsQuery());

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

        //Get single payment
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

        //Add new payment
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreatePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreatePaymentCommand payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var paymentSend = await _mediator.Send(payment);
                return Created($"api/payments/{paymentSend.Id}", _mapper.Map<CreatePaymentResponse>(payment));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change payment
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdatePaymentResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdatePaymentCommand payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var paymentSend = await _mediator.Send(payment);
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

        //Delete payment
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