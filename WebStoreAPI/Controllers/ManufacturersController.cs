﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandAndQuerySeparation.Commands.Manufacturers;
using CommandAndQuerySeparation.Queries.Manufacturers;
using CommandAndQuerySeparation.Response.Manufacturers;
using DataLibrary.Entities;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        //Setup connection
        public ManufacturersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Get list of cities
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetAllManufacturersResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var manufacturers = await _mediator.Send(new GetAllManufacturersQuery());

                if (!manufacturers.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetAllManufacturersResponse>>(manufacturers));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single city
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetManufacturerByIdResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var manufacturer = await _mediator.Send(new GetManufacturerByIdQuery { Id = id } );

                if (manufacturer == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetManufacturerByIdResponse>(manufacturer));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new city
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateManufacturerCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateManufacturerCommand manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(manufacturer);
                return Ok(manufacturer);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change city
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateManufacturerCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateManufacturerCommand manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var manufacturerSend = await _mediator.Send(manufacturer);
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

        //Delete city
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Manufacturer))]
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