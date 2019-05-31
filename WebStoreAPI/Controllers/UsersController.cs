using AutoMapper;
using CQS.Commands.Users;
using CQS.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAPI.Requests.Users;
using WebStoreAPI.Response.Users;
using WebStoreAPI.Specifications.Users;

namespace WebStoreAPI.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Users controller
    /// </summary>
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
        /// Get all Users
        /// </summary>
        /// <returns>List with all Users</returns>
        /// <responce code="200">Get Users by filter</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Users not found</responce>
        /// <responce code="500">Internal error</responce>
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
                    _logger.LogInformation("GET USERS, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USERS, CONTROLLER - Complete");
                return Ok(_mapper.Map<IEnumerable<GetUsersResponse>>(users));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USERS, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Get User by their ID
        /// </summary>
        /// <param name="id">The ID of the desired User</param>
        /// <returns>Info about User with selected Id</returns>
        /// <responce code="200">Get User by Id</responce>
        /// <responce code="204">No content</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">User not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserQuery { Id = id });

                if (user == null)
                {
                    _logger.LogInformation("GET USER, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("GET USER, CONTROLLER - Complete");
                return Ok(_mapper.Map<GetUserResponse>(user));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Create a new User
        /// </summary>
        /// <param name="user">The body of new User</param>
        /// <returns>Info about created User</returns>
        /// <responce code="200">Create User</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("CREATE USER, CONTROLLER - Not valid");
                return BadRequest();
            }

            try
            {
                var userSend = await _mediator.Send(_mapper.Map<CreateUserCommand>(user));
                _logger.LogInformation("CREATE USER, CONTROLLER - Complete, with id: " + userSend.Id);
                return Created($"api/users/{userSend.Id}", _mapper.Map<CreateUserResponse>(userSend));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE USER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Update existing User
        /// </summary>
        /// <param name="user">The body of new User</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Update User</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">User not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UpdateUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("UPDATE USER, CONTROLLER - Not valid");
                return BadRequest(ModelState);
            }

            try
            {
                var userSend = await _mediator.Send(_mapper.Map<UpdateUserCommand>(user));
                if (userSend == null)
                {
                    _logger.LogInformation("UPDATE USER, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("UPDATE USER, CONTROLLER - Complete, with id: " + userSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE USER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Delete existing User
        /// </summary>
        /// <param name="id">The ID of the desired User</param>
        /// <returns>Nothing</returns>
        /// <responce code="200">Delete User</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">User not found</responce>
        /// <responce code="500">Internal error</responce>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(DeleteUserResponse))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userSend = await _mediator.Send(new DeleteUserCommand { Id = id });
                if (userSend == null)
                {
                    _logger.LogInformation("DELETE USER, CONTROLLER - Not found");
                    return NotFound();
                }

                _logger.LogInformation("DELETE USER, CONTROLLER - Complete, with id: " + userSend.Id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE USER, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}