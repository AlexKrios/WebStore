using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Manufacturers;
using CQS.Queries.Manufacturers;
using WebStoreAPI.Requests.Manufacturers;
using WebStoreAPI.Response.Manufacturers;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ManufacturersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Manufacturers.
        /// </summary>
        /// <returns>List with all Manufacturers.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetManufacturersResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var manufacturers = await _mediator.Send(new GetManufacturersQuery());

                if (!manufacturers.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetManufacturersResponse>>(manufacturers));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Manufacturer by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Manufacturer.</param>
        /// <returns>Info about Manufacturer with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetManufacturerResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var manufacturer = await _mediator.Send(new GetManufacturerQuery { Id = id } );

                if (manufacturer == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetManufacturerResponse>(manufacturer));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Manufacturer.
        /// </summary>
        /// <param name="manufacturer">The body of new Manufacturer.</param>
        /// <returns>Info about created Manufacturer.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateManufacturerResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateManufacturerRequest manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var manufacturerSend = await _mediator.Send(_mapper.Map<CreateManufacturerCommand>(manufacturer));
                return Created($"api/manufacturers/{manufacturerSend.Id}", _mapper.Map<CreateManufacturerResponse>(manufacturerSend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Manufacturer.
        /// </summary>
        /// <param name="manufacturer">The body of new Manufacturer.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateManufacturerResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateManufacturerRequest manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var manufacturerSend = await _mediator.Send(_mapper.Map<UpdateManufacturerCommand>(manufacturer));
                if (manufacturerSend == null)
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
        /// Delete existing Manufacturer.
        /// </summary>
        /// <param name="id">The ID of the desired Manufacturer.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteManufacturerResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var manufacturerSend = await _mediator.Send(new DeleteManufacturerCommand { Id = id });
                if (manufacturerSend == null)
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