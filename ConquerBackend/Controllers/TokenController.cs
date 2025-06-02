using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConquerBackend.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ConquerBackend.Presentation.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TokenController(IConfiguration configuration) : ControllerBase
    {
        [HttpPost("token")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var defaultUsername = configuration["DefaultAdmin:Username"];
            var defaultPassword = configuration["DefaultAdmin:Password"];
            var defaultRole = configuration["DefaultAdmin:Role"];

            if (request.Username == defaultUsername && request.Password == defaultPassword)
            {
                var token = GenerateJwtToken(defaultUsername, defaultRole);
                return Ok(new LoginResponse
                {
                    Token = token,
                    Username = defaultUsername,
                    Role = defaultRole
                });
            }

            return Unauthorized("Thông tin đăng nhập không hợp lệ.");
        }

        private string GenerateJwtToken(string username, string role)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
