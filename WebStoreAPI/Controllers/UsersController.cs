using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Users;
using CQS.Queries.Users;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.Users;
using WebStoreAPI.Response.Users;
using WebStoreAPI.Specifications.Users;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, IMapper mapper, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Users.
        /// </summary>
        /// <returns>List with all Users.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetUsersResponse>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery]GetUsersRequest request)
        {
            try
            {
                var nameSpec = new UserNameSpecification(request.Name);
                var minAgeSpec = new UserMinAgeSpecification(request.MinAge);
                var maxAgeSpec = new UserMaxAgeSpecification(request.MaxAge);
                var emailSpec = new UserEmailSpecification(request.Email);
                var cityIdSpec = new UserCityIdSpecification(request.CityId);

                var specification = nameSpec && minAgeSpec && maxAgeSpec && emailSpec && cityIdSpec;

                var users = await _mediator.Send(new GetUsersQuery { Specification = specification });

                if (!users.Any())
                {
                    _logger.LogError("GET USERS - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USERS - Complete");
                return Ok(_mapper.Map<IEnumerable<GetUsersResponse>>(users));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET USERS - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get User by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired User.</param>
        /// <returns>Info about User with selected Id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserQuery { Id = id } );

                if (user == null)
                {
                    _logger.LogError("GET USER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USER - Complete");
                return Ok(_mapper.Map<GetUserResponse>(user));
            }
            catch (Exception e)
            {
                _logger.LogError($"GET USER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new User.
        /// </summary>
        /// <param name="user">The body of new User.</param>
        /// <returns>Info about created User.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("POST USER - Not valid");
                return BadRequest();
            }

            try
            {
                var userSend = await _mediator.Send(_mapper.Map<CreateUserCommand>(user));
                _logger.LogInformation("POST USER - Complete, with id: " + userSend.Id);
                return Created($"api/users/{userSend.Id}", _mapper.Map<CreateUserResponse>(userSend));
            }
            catch (Exception e)
            {
                _logger.LogError($"POST USER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing User.
        /// </summary>
        /// <param name="user">The body of new User.</param>
        /// <returns>Nothing</returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("PUT USER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var userSend = await _mediator.Send(_mapper.Map<UpdateUserCommand>(user));
                if (userSend == null)
                {
                    _logger.LogError("PUT USER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("PUT USER - Complete, with id: " + userSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"PUT USER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing User.
        /// </summary>
        /// <param name="id">The ID of the desired User.</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userSend = await _mediator.Send(new DeleteUserCommand{ Id = id });
                if (userSend == null)
                {
                    _logger.LogError("DELETE USER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE USER - Complete, with id: " + userSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"DELETE USER - {e}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}