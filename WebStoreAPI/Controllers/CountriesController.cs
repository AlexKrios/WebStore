﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAndQuerySeparation.Commands.Countries;
using CommandAndQuerySeparation.Queries.Countries;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of countries
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var countries = await _mediator.Send(new GetAllCountriesQuery());

                if (!countries.Any())
                {
                    return NotFound();
                }

                return Ok(countries);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single country
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var country = await _mediator.Send(new GetCountryByIdQuery(id));

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new country
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateCountryCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateCountryCommand country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(country);
                return Ok(country);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change country
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateCountryCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateCountryCommand country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var countrySend = await _mediator.Send(country);
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

        //Delete country
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Country))]
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