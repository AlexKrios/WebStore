using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth;
using DataLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly WebStoreContext _context;

        public AuthController (IConfiguration config, WebStoreContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet("token")]
        public IActionResult Get()
        {
            try
            {
                var header = Request.Headers["Authorization"];
                if (header.ToString().StartsWith("Basic"))
                {
                    var credValue = header.ToString().Substring("Basic ".Length).Trim();
                    var userNameAndPassEnc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                    var userNameAndPass = userNameAndPassEnc.Split(":");

                    if (new UserLogin(_context).DataCheck(userNameAndPass[0], userNameAndPass[1]))
                    {
                        var claimsData = new[] { new Claim(ClaimTypes.Name, userNameAndPass[0]) };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                        var token = new JwtSecurityToken(
                            //audience: _config["Jwt:Audience"],
                            //issuer: _config["Jwt:Issuer"],
                            expires: DateTime.Now.AddMinutes(60),
                            claims: claimsData,
                            signingCredentials: signInCred
                        );

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    return Unauthorized();
                }
                return BadRequest("Wrong request");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }
    }
}