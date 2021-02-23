using AuthenticationAndAuthorization.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAndAuthorization.Services
{
    public class TokenService
    {
        private readonly TokenConfigure _configuration;
        private const double ExpireHours = 1.0;

        public TokenService(IOptions<TokenConfigure> options)
        {
            _configuration = options.Value;
        }
        public string CreateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.Key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.Username),
                    new(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(ExpireHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
      }
}
