using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Countries;
using CQS.Queries.Countries;
using WebStoreAPI.Requests.Countries;
using WebStoreAPI.Response.Countries;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CountriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Countries.
        /// </summary>
        /// <returns>List with all Countries.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetCountriesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var countries = await _mediator.Send(new GetCountriesQuery());

                if (!countries.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetCountriesResponse>>(countries));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Country by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Country.</param>
        /// <returns>Info about Country with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetCountryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var country = await _mediator.Send(new GetCountryQuery { Id = id } );

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetCountryResponse>(country));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Country.
        /// </summary>
        /// <param name="country">The body of new Country.</param>
        /// <returns>Info about created Country.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateCountryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateCountryRequest country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var countrySend = await _mediator.Send(_mapper.Map<CreateCountryCommand>(country));
                return Created($"api/countries/{countrySend.Id}", _mapper.Map<CreateCountryResponse>(countrySend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Country.
        /// </summary>
        /// <param name="country">The body of new Country.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateCountryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateCountryRequest country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var countrySend = await _mediator.Send(_mapper.Map<UpdateCountryCommand>(country));
                if (countrySend == null)
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
        /// Delete existing Country.
        /// </summary>
        /// <param name="id">The ID of the desired Country.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteCountryResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var countrySend = await _mediator.Send(new DeleteCountryCommand { Id = id });
                if (countrySend == null)
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