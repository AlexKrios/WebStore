using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Cities;
using CQS.Queries.Cities;
using Specification.Requests.Cities;
using WebStoreAPI.Response.Cities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CitiesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Cities.
        /// </summary>
        /// <returns>List with all Cities.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetCitiesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetCitiesRequest filter)
        {
            try
            {
                var cities = await _mediator.Send(new GetCitiesQuery(filter));

                if (!cities.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetCitiesResponse>>(cities));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Get City by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired City.</param>
        /// <returns>Info about City with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetCityResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var city = await _mediator.Send(new GetCityQuery {Id = id});

                if (city == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetCityResponse>(city));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Create a new City.
        /// </summary>
        /// <param name="city">The body of new City.</param>
        /// <returns>Info about created City.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateCityResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateCityRequest city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var citySend = await _mediator.Send(_mapper.Map<CreateCityCommand>(city));
                return Created($"api/cities/{citySend.Id}", _mapper.Map<CreateCityResponse>(citySend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Update existing City.
        /// </summary>
        /// <param name="city">The body of new City.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateCityResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateCityRequest city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var citySend = await _mediator.Send(_mapper.Map<UpdateCityCommand>(city));
                if (citySend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }

        /// <summary>
        /// Delete existing City.
        /// </summary>
        /// <param name="id">The ID of the desired City.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteCityResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var citySend = await _mediator.Send(new DeleteCityCommand {Id = id});
                if (citySend == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}