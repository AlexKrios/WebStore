using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Types;
using CQS.Queries.Types;
using Specification.Requests.Types;
using WebStoreAPI.Response.Types;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TypesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Types.
        /// </summary>
        /// <returns>List with all Types.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetTypesResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetTypesRequest filter)
        {
            try
            {
                var types = await _mediator.Send(new GetTypesQuery(filter));

                if (!types.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<GetTypesResponse>>(types));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get Type by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Type.</param>
        /// <returns>Info about Type with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetTypeResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var type = await _mediator.Send(new GetTypeQuery { Id = id } );

                if (type == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<GetTypeResponse>(type));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new Type.
        /// </summary>
        /// <param name="type">The body of new Type.</param>
        /// <returns>Info about created Type.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateTypeResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateTypeRequest type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var typeSend = await _mediator.Send(_mapper.Map<CreateTypeCommand>(type));
                return Created($"api/types/{typeSend.Id}", _mapper.Map<CreateTypeResponse>(typeSend));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing Type.
        /// </summary>
        /// <param name="type">The body of new Type.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateTypeResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateTypeRequest type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var typeSend = await _mediator.Send(_mapper.Map<UpdateTypeCommand>(type));
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

        /// <summary>
        /// Delete existing Type.
        /// </summary>
        /// <param name="id">The ID of the desired Type.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteTypeResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var typeSend = await _mediator.Send(new DeleteTypeCommand { Id = id});
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