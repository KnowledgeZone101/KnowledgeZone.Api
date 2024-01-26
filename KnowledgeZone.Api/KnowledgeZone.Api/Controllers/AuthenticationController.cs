using KnowledgeZone.Api.LoginModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KnowledgeZone.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        [HttpPost("login")]
        public ActionResult<string> Login(LoginRequest loginRequest)
        {
            var user = Authenticate(loginRequest.Login, loginRequest.Password, loginRequest.Name, loginRequest.Email);

            if (user is null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KnowledgeZoneSecretKey@123"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("Login", user.Login));
            claimsForToken.Add(new Claim("Name", user.Name));
            claimsForToken.Add(new Claim("Email", user.Email));

            var jwtSecurityToken = new JwtSecurityToken(
                "knowledgeZoneApi",
                "Api", 
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(30));

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(token);
        }
        static User Authenticate(string login, string password, string name, string email)
        {
            return new User
            {
                Login = login,
                Password = password,
                Name = name,
                Email = email
            };
        }
    }
}
