using CQS.Commands.Auth;
using CQS.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using WebStoreAPI.Requests.Auth;
using WebStoreAPI.Response.Auth;
using WebStoreAPI.Utils;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public AuthController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _config = config;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateToken([FromBody] CreateTokenRequest login)
        {
            try
            {
                var refreshToken = await _mediator.Send(new CreateTokenCommand
                {
                    Login = login.Login,
                    Password = login.Password
                });

                if (refreshToken == null)
                {
                    return BadRequest();
                }

                var token = new AuthTokenGenerator(_config).GenerateToken();

                var tokenResponse = new CreateTokenResponse
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken.Token,
                    TokenExpiration = token.ValidTo
                };

                return Ok(tokenResponse);
            }
            catch (UnauthorizedException)
            {
                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshToken)
        {
            try
            {
                var refreshTokenSend = await _mediator.Send(new RefreshTokenCommand { Token = refreshToken.Token });

                if (refreshTokenSend == null)
                {
                    return BadRequest();
                }

                var token = new AuthTokenGenerator(_config).GenerateToken();

                var tokenResponse = new CreateTokenResponse
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken.Token,
                    TokenExpiration = token.ValidTo
                };

                return Ok(tokenResponse);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ExpiredTokenException)
            {
                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}