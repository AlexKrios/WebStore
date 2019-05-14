using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Cities;
using CQS.Queries.Cities;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.Cities;
using WebStoreAPI.Response.Cities;
using WebStoreAPI.Specifications.Cities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(IMediator mediator, IMapper mapper, ILogger<CitiesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Cities.
        /// </summary>
        /// <returns>List with all Cities.</returns>
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
                    _logger.LogError("GET CITIES - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET CITIES - Complete");
                return Ok(_mapper.Map<IEnumerable<GetCitiesResponse>>(cities));
            }
            catch (Exception e)
            {
                _logger.LogError(@"GET CITIES - {0}", e);
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
                var city = await _mediator.Send(new GetCityQuery { Id = id });

                if (city == null)
                {
                    _logger.LogError("Not found city object by id in GET request");
                    return NotFound();
                }

                _logger.LogInformation("Complete, get city by id");
                return Ok(_mapper.Map<GetCityResponse>(city));
            }
            catch (Exception e)
            {
                _logger.LogError("Unknown exception in GET city by id request");
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
                _logger.LogError("City model is not valid in POST request");
                return BadRequest(ModelState);
            }

            try
            {
                var citySend = await _mediator.Send(_mapper.Map<CreateCityCommand>(city));
                _logger.LogInformation("Complete, create new city with id: " + citySend.Id);
                return Created($"api/cities/{citySend.Id}", _mapper.Map<CreateCityResponse>(citySend));
            }
            catch (Exception e)
            {
                _logger.LogError("Unknown exception in POST city request");
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
                _logger.LogError("City model is not valid in UPDATE request");
                return BadRequest(ModelState);
            }

            try
            {
                var citySend = await _mediator.Send(_mapper.Map<UpdateCityCommand>(city));
                if (citySend == null)
                {
                    _logger.LogError("Not found city object by id in UPDATE request");
                    return NotFound();
                }

                _logger.LogInformation("Complete, update city with id: " + citySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Unknown exception in UPDATE city request");
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
            try
            {
                var citySend = await _mediator.Send(new DeleteCityCommand {Id = id});
                if (citySend == null)
                {
                    _logger.LogError("Not found city object by id in DELETE request");
                    return NotFound();
                }

                _logger.LogInformation("Complete, delete city with id: " + citySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Unknown exception id DELETE city request");
                return StatusCode(500, new {errorMessage = e.Message});
            }
        }
    }
}