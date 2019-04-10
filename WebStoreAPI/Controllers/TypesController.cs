using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandAndQuerySeparation.Commands.Types;
using CommandAndQuerySeparation.Queries.Types;
using DataLibrary.Entities;
using Type = DataLibrary.Entities.Type;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public TypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of types
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Type>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var types = await _mediator.Send(new GetAllTypesQuery());

                if (!types.Any())
                {
                    return NotFound();
                }

                return Ok(types);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Get single type
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(City))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var type = await _mediator.Send(new GetTypeByIdQuery(id));

                if (type == null)
                {
                    return NotFound();
                }

                return Ok(type);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Add new type
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateTypeCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateTypeCommand type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(type);
                return Ok(type);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change type
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateTypeCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateTypeCommand type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var typeSend = await _mediator.Send(type);
                if (typeSend == null)
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
                var typeSend = await _mediator.Send(new DeleteTypeCommand(id));
                if (typeSend == null)
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