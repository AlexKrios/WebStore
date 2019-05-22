using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Countries;
using CQS.Queries.Countries;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.Countries;
using WebStoreAPI.Response.Countries;
using WebStoreAPI.Specifications.Countries;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(IMediator mediator, IMapper mapper, ILogger<CountriesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Countries.
        /// </summary>
        /// <returns>List with all Countries.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetCountriesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetCountriesRequest request)
        {
            try
            {
                var nameSpec = new CountryNameSpecification(request.Name);

                var countries = await _mediator.Send(new GetCountriesQuery { Specification = nameSpec });

                if (!countries.Any())
                {
                    _logger.LogError("GET COUNTRIES - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET COUNTRIES - Complete");
                return Ok(_mapper.Map<IEnumerable<GetCountriesResponse>>(countries));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET COUNTRIES - {e}");
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
                    _logger.LogError("GET COUNTRY - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET COUNTRY - Complete");
                return Ok(_mapper.Map<GetCountryResponse>(country));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET COUNTRY - {e}");
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
                _logger.LogError("POST COUNTRY - Not valid");
                return BadRequest();
            }

            try
            {
                var countrySend = await _mediator.Send(_mapper.Map<CreateCountryCommand>(country));
                _logger.LogInformation("POST COUNTRY - Complete, with id: " + countrySend.Id);
                return Created($"api/countries/{countrySend.Id}", _mapper.Map<CreateCountryResponse>(countrySend));
            }
            catch (Exception e)
            {
                _logger.LogError($"POST COUNTRY - {e}");
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
                _logger.LogError("PUT COUNTRY - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var countrySend = await _mediator.Send(_mapper.Map<UpdateCountryCommand>(country));
                if (countrySend == null)
                {
                    _logger.LogError("PUT COUNTRY - Not found");
                    return NotFound();
                }

                _logger.LogInformation("PUT COUNTRY - Complete, with id: " + countrySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"PUT COUNTRY - {e}");
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
            try
            {
                var countrySend = await _mediator.Send(new DeleteCountryCommand { Id = id });
                if (countrySend == null)
                {
                    _logger.LogError("DELETE COUNTRY - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE COUNTRY - Complete, with id: " + countrySend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"DELETE COUNTRY - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}