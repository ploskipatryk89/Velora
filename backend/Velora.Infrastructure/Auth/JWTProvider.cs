
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Domain.Entities;

namespace Velora.Infrastructure.Auth
{
    public class JWTProvider : IJwtProvider
    {
        private readonly IConfiguration _configuration;
        public JWTProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                  );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
             issuer: _configuration["Jwt:Issuer"],
             audience: _configuration["Jwt:Audience"],
             claims: claims,
             expires: DateTime.UtcNow.AddHours(2),
             signingCredentials: creds
         );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
