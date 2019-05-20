using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Cities;
using CQS.Queries.Cities;
using WebStoreAPI.Requests.Cities;
using WebStoreAPI.Response.Cities;
using WebStoreAPI.Specifications.Cities;

namespace WebStoreAPI.Controllers
{
    /// <summary>
    /// Cities controller
    /// </summary>
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
        /// Get all Cities
        /// </summary>
        /// <returns>List with all Cities</returns>
        /// <responce code="200">Get Cities by filter</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Cities not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetCitiesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetCitiesRequest request)
        {
            try
            {
                var nameSpec = new CityNameSpecification(request.Name);
                var countryIdSpec = new CityCountryIdSpecification(request.CountryId);

                var specification = nameSpec && countryIdSpec;

                var cities = await _mediator.Send(new GetCitiesQuery { Specification = specification });

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
        /// Get City by their ID
        /// </summary>
        /// <param name="id">The ID of the desired City</param>
        /// <returns>Info about City with selected Id</returns>
        /// <responce code="200">Get City by Id</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">City not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetCityResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var city = await _mediator.Send(new GetCityQuery { Id = id });

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
        /// Create a new City
        /// </summary>
        /// <param name="city">The body of new City</param>
        /// <returns>Info about created City</returns>
        /// <responce code="200">Create City</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="500">Internal error</responce>
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
        /// Update existing City
        /// </summary>
        /// <param name="city">The body of new City</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Update City</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">City not found</responce>
        /// <responce code="500">Internal error</responce>
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
        /// Delete existing City
        /// </summary>
        /// <param name="id">The ID of the desired City</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Delete City</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">City not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteCityResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
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