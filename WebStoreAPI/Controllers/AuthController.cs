using CQS.Commands.Auth;
using CQS.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebStoreAPI.Requests.Auth;
using WebStoreAPI.Response.Auth;
using WebStoreAPI.Utils;

namespace WebStoreAPI.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Auth controller
    /// </summary>
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator, IConfiguration config, ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _config = config;
            _logger = logger;
        }

        /// <summary>
        /// Create Token
        /// </summary>
        /// <returns>Info about Token</returns>
        /// <responce code="200">Create Token</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Token not found</responce>
        /// <responce code="500">Internal error</responce>
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
                _logger.LogInformation("CREATE TOKEN, CONTROLLER - Unauthorized");
                return Unauthorized();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE TOKEN, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <returns>Info about Token</returns>
        /// <responce code="200">Create Token</responce>
        /// <responce code="400">Bad request</responce>
        /// <responce code="401">Unauthorized</responce>
        /// <responce code="404">Token not found</responce>
        /// <responce code="500">Internal error</responce>
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
                _logger.LogInformation("REFRESH TOKEN, CONTROLLER - Not found");
                return NotFound();
            }
            catch (ExpiredTokenException)
            {
                _logger.LogInformation("REFRESH TOKEN, CONTROLLER - Expired token");
                return Unauthorized();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"REFRESH TOKEN, CONTROLLER - {e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}