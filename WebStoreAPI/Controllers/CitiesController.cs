using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Entities;
using WebStoreAPI.Commands.Cities;
using WebStoreAPI.Queries.Cities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of cities
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<City>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _mediator.Send(new GetAllCitiesQuery());

                if (!users.Any())
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single city
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(City))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetCityByIdQuery(id));

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new city
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateCityCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateCityCommand city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(city);
                return Ok(city);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change city
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateCityCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateCityCommand city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var citySend = await _mediator.Send(city);
                if (citySend == null)
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

        //Delete city
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(City))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var citySend = await _mediator.Send(new DeleteCityCommand(id));
                if (citySend == null)
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