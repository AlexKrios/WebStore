using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebStoreAPI.Utils
{
    public class AuthTokenGenerator
    {
        private readonly IConfiguration _config;

        public AuthTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        public JwtSecurityToken GenerateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(double.Parse(_config["Jwt:ExpireMinutes"]));

            var token = new JwtSecurityToken(
                audience: _config["Jwt:Audience"],
                issuer: _config["Jwt:Issuer"],
                expires: expires,
                signingCredentials: signInCred
            );

            return token;
        }
    }
}
