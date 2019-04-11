﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandAndQuerySeparation.Commands.Cities;
using CommandAndQuerySeparation.Queries.Cities;
using CommandAndQuerySeparation.Response.Cities;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public CitiesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of cities
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetAllCitiesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cities = await _mediator.Send(new GetAllCitiesQuery());

                if (!cities.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetAllCitiesResponse>>(cities));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single city
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetCityByIdResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var city = await _mediator.Send(new GetCityByIdQuery { Id = id } );

                if (city == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetCityByIdResponse>(city));
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
                var citySend = await _mediator.Send(new DeleteCityCommand { Id = id });
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