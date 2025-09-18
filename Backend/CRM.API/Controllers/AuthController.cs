using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CRM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CRM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            
            if (user is null || !await userManager.CheckPasswordAsync(user, dto.Password))
            {
                return Unauthorized();
            }

            var roles = await userManager.GetRolesAsync(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }.Concat(roles.Select(r => new Claim(ClaimTypes.Role, r)))),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(config["Jwt:ExpiryMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = config["Jwt:Issuer"],
                Audience = config["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {Token = tokenHandler.WriteToken(token)});
        }
    }

    public record LoginDto(string Email, string Password);
}
