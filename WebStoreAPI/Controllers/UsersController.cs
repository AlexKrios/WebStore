using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Entities;
using WebStoreAPI.Commands.Users;
using WebStoreAPI.Queries.Users;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        //Setup connection
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get list of users
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());

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

        //Get single user
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserByIdQuery(id));

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

        //Get group of user
        //[HttpGet("{role}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        //[ProducesResponseType(500, Type = typeof(string))]
        //public async Task<IActionResult> GetUserByRole(string role)
        //{
        //    try
        //    {
        //        var users = await _mediator.Send(new GetUsersByRoleQuery(role));

        //        if (!users.Any())
        //        {
        //            return NotFound();
        //        }

        //        return Ok(users);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, new { errorMessage = e.Message });
        //    }
        //}

        //Add new user
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserCommand))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Add(CreateUserCommand user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _mediator.Send(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        //Change user
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Update(UpdateUserCommand user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userSend = await _mediator.Send(user);
                if (userSend == null)
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

        //Delete user
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(500, Type = typeof(string))]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userSend = await _mediator.Send(new DeleteUserCommand(id));
                if (userSend == null)
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